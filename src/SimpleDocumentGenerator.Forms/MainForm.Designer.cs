
namespace SimpleDocumentGenerator.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelMain = new System.Windows.Forms.Panel();
            this.ButtonBold = new System.Windows.Forms.Button();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.RichTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.PictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.FlowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelMain.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMain.Controls.Add(this.ButtonBold);
            this.PanelMain.Controls.Add(this.LabelDescription);
            this.PanelMain.Controls.Add(this.RichTextBoxDescription);
            this.PanelMain.Controls.Add(this.LabelTitle);
            this.PanelMain.Controls.Add(this.TextBoxTitle);
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(1);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(729, 143);
            this.PanelMain.TabIndex = 0;
            // 
            // ButtonBold
            // 
            this.ButtonBold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonBold.Location = new System.Drawing.Point(79, 35);
            this.ButtonBold.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonBold.Name = "ButtonBold";
            this.ButtonBold.Size = new System.Drawing.Size(20, 24);
            this.ButtonBold.TabIndex = 4;
            this.ButtonBold.Text = "B";
            this.ButtonBold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonBold.UseVisualStyleBackColor = true;
            this.ButtonBold.Click += new System.EventHandler(this.ButtonBold_Click);
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Location = new System.Drawing.Point(8, 41);
            this.LabelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(67, 15);
            this.LabelDescription.TabIndex = 3;
            this.LabelDescription.Text = "Description";
            // 
            // RichTextBoxDescription
            // 
            this.RichTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxDescription.Location = new System.Drawing.Point(8, 62);
            this.RichTextBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.RichTextBoxDescription.Name = "RichTextBoxDescription";
            this.RichTextBoxDescription.Size = new System.Drawing.Size(718, 81);
            this.RichTextBoxDescription.TabIndex = 1;
            this.RichTextBoxDescription.Text = "";
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Location = new System.Drawing.Point(8, 8);
            this.LabelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(29, 15);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Title";
            // 
            // TextBoxTitle
            // 
            this.TextBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTitle.Location = new System.Drawing.Point(43, 7);
            this.TextBoxTitle.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.Size = new System.Drawing.Size(684, 23);
            this.TextBoxTitle.TabIndex = 0;
            // 
            // PanelButtons
            // 
            this.PanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelButtons.Controls.Add(this.PictureBoxLoading);
            this.PanelButtons.Controls.Add(this.ButtonSave);
            this.PanelButtons.Controls.Add(this.ButtonSearch);
            this.PanelButtons.Location = new System.Drawing.Point(729, 0);
            this.PanelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(99, 143);
            this.PanelButtons.TabIndex = 1;
            // 
            // PictureBoxLoading
            // 
            this.PictureBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxLoading.Image")));
            this.PictureBoxLoading.Location = new System.Drawing.Point(9, 63);
            this.PictureBoxLoading.Name = "PictureBoxLoading";
            this.PictureBoxLoading.Size = new System.Drawing.Size(79, 81);
            this.PictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxLoading.TabIndex = 4;
            this.PictureBoxLoading.TabStop = false;
            this.PictureBoxLoading.Visible = false;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Location = new System.Drawing.Point(10, 37);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(78, 23);
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.Location = new System.Drawing.Point(10, 7);
            this.ButtonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(78, 23);
            this.ButtonSearch.TabIndex = 2;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // FlowLayoutPanelImages
            // 
            this.FlowLayoutPanelImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanelImages.AutoScroll = true;
            this.FlowLayoutPanelImages.Location = new System.Drawing.Point(8, 147);
            this.FlowLayoutPanelImages.Margin = new System.Windows.Forms.Padding(2);
            this.FlowLayoutPanelImages.Name = "FlowLayoutPanelImages";
            this.FlowLayoutPanelImages.Size = new System.Drawing.Size(813, 191);
            this.FlowLayoutPanelImages.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 346);
            this.Controls.Add(this.FlowLayoutPanelImages);
            this.Controls.Add(this.PanelButtons);
            this.Controls.Add(this.PanelMain);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MinimumSize = new System.Drawing.Size(495, 325);
            this.Name = "MainForm";
            this.Text = "Simple Document Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.TextBox TextBoxTitle;
        private System.Windows.Forms.RichTextBox RichTextBoxDescription;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelImages;
        private System.Windows.Forms.Button ButtonBold;
        private System.Windows.Forms.PictureBox PictureBoxLoading;
    }
}

