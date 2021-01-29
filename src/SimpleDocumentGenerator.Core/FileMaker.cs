using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorLight;
using RtfPipe;

namespace SimpleDocumentGenerator.Core
{
    public class FileMaker
    {
        private readonly RazorLightEngine _engine;

        /// <summary>
        /// </summary>
        public FileMaker()
        {
            _engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(TemplateModel))
                .SetOperatingAssembly(typeof(TemplateModel).Assembly)
                .UseMemoryCachingProvider()
                .Build();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public async Task SaveAsync(string filePath, TemplateModel templateModel)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SimpleDocumentGenerator.Core.Template.cshtml";
            string template;

            using (var manifestStream = assembly.GetManifestResourceStream(resourceName))
            using (var streamReader = new StreamReader(manifestStream))
            {
                template = await streamReader.ReadToEndAsync();
            }

            templateModel.Description = Rtf.ToHtml(templateModel.Description);

            var compiledResult = await _engine.CompileRenderStringAsync("V1", template, templateModel);

            using (var streamWriter = new StreamWriter(filePath))
            {
                await streamWriter.WriteAsync(compiledResult);
            }
        }
    }
}