using Microsoft.AspNetCore.Html;

namespace SimpleDocumentGenerator.Core
{
    public class TemplateModel
    {
        public string TitleText { get; set; }

        public string Description { get; set; }

        public IHtmlContent HtmlStringDescription => new HtmlString(Description);

        public string[] BoldWords { get; set; }

        public string[] ImageLinks { get; set; }
    }
}