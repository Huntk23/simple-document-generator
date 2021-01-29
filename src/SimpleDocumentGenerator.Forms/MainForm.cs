using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SimpleDocumentGenerator.Core;
using SimpleDocumentGenerator.Forms.Properties;

namespace SimpleDocumentGenerator.Forms
{
    public partial class MainForm : Form
    {
        #region Fields

        private readonly FileMaker _fileMaker;
        private readonly ImageUtility _imageUtility;

        private List<string> _listOfSearchWords;
        private List<string> _listOfImageLinks;
        private List<int> _listOfSelectedImageIndexes;

        private ToolTip _toolTip;

        #endregion

        #region Constructor

        public MainForm(FileMaker fileMaker, ImageUtility imageUtility)
        {
            InitializeComponent();

            _fileMaker = fileMaker;
            _imageUtility = imageUtility;
            _listOfSearchWords = new List<string>();
            _listOfImageLinks = new List<string>();
        }

        #endregion

        #region Form Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            _listOfSelectedImageIndexes = new List<int>();

            _toolTip = new ToolTip();
            _toolTip.SetToolTip(ButtonBold, "Ctrl + B - Highlight text to bold");
        }

        #endregion

        #region Button Events

        private async void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {
                MessageBox.Show("Unable to search for images, title text box is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            VerifySearchWords();

            ToggleLoadingRing(true);

            _listOfImageLinks.Clear();

            try
            {
                throw new Exception("429");
                _listOfImageLinks = await _imageUtility.SearchForImages(_listOfSearchWords);
            }
            catch (Exception exception) when (exception.Message.Contains("429"))
            {
                MessageBox.Show($"Too many requests have been made with a free Google Search Custom API Key: {exception.Message}" +
                                $"{Environment.NewLine}Using fall back links.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _listOfImageLinks.AddRange(Resources.FallbackLinks.Split('|')); // Sloppy, but got the job done for testing after hitting API limit
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An unknown error occurred while retrieving images: {exception.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleLoadingRing(false);
                return;
            }

            FillPictureBoxes();

            ToggleLoadingRing(false);
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_listOfSelectedImageIndexes.Count == 0)
            {
                MessageBox.Show("Images have not been selected, please select images to add to document.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "HTML file (*.html)|*.html";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var templateModel = new TemplateModel
                    {
                        TitleText = TextBoxTitle.Text,
                        Description = RichTextBoxDescription.Rtf,
                        BoldWords = _listOfSearchWords.ToArray(),
                        ImageLinks = _listOfSelectedImageIndexes.Select(i => _listOfImageLinks[i]).ToArray()
                    };

                    ToggleLoadingRing(true);

                    await _fileMaker.SaveAsync(Path.ChangeExtension(saveFileDialog.FileName, ".html"), templateModel);

                    ToggleLoadingRing(false);
                }

                MessageBox.Show($"SaveAsync file complete: {saveFileDialog.FileName}");
            }

            // TODO: Reset method
            TextBoxTitle.Text = string.Empty;
            RichTextBoxDescription.Clear();
            _listOfSearchWords.Clear();
        }

        private void ButtonBold_Click(object sender, EventArgs e)
        {
            RichTextBoxDescription.SelectionFont = new Font(RichTextBoxDescription.Font, RichTextBoxDescription.SelectionFont.Style ^ FontStyle.Bold);

            if (_listOfSearchWords.Contains(RichTextBoxDescription.SelectedText))
            {
                _listOfSearchWords.Remove(RichTextBoxDescription.SelectedText);
            }
            else
            {
                _listOfSearchWords.Add(RichTextBoxDescription.SelectedText);
            }
        }

        #endregion

        #region Hotkeys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.B))
            {
                ButtonBold.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void VerifySearchWords()
        {
            _listOfSearchWords.Insert(0, TextBoxTitle.Text);

            if (_listOfSearchWords.Count > 1) // Check for bold search words
            {
                for (int idx = 1; idx < _listOfSearchWords.Count; idx++)
                {
                    var searchWord = _listOfSearchWords[idx];

                    if (!RichTextBoxDescription.Text.Contains(searchWord)) // Bold word was removed by deletion instead of removing bold
                    {
                        _listOfSearchWords.RemoveAt(idx);
                    }
                }
            }
        }

        private void FillPictureBoxes()
        {
            for (var index = 0; index < _listOfImageLinks.Count; index++)
            {
                var imageLink = _listOfImageLinks[index];

                var pictureBox = new PictureBox
                {
                    ImageLocation = imageLink,
                    Size = new Size(380, 380),
                    SizeMode = PictureBoxSizeMode.AutoSize
                };

                var checkBox = new CheckBox
                {
                    Tag = index
                };

                checkBox.Click += CheckBoxOnClick;

                var panel = new FlowLayoutPanel
                {
                    AutoScroll = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(380, 380)
                };

                panel.Controls.Add(checkBox);
                panel.Controls.Add(pictureBox);

                FlowLayoutPanelImages.Controls.Add(panel);
            }
        }

        private void CheckBoxOnClick(object sender, EventArgs e)
        {
            var checkBox = (CheckBox) sender;
            var checkBoxIndex = (int) checkBox.Tag;

            if (_listOfSelectedImageIndexes.Contains(checkBoxIndex))
            {
                _listOfSelectedImageIndexes.Remove(checkBoxIndex);
            }
            else
            {
                _listOfSelectedImageIndexes.Add(checkBoxIndex);
            }
        }

        private void ToggleLoadingRing(bool showPanel)
        {
            PictureBoxLoading.Visible = showPanel;
        }
    }
}
