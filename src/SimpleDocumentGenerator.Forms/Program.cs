using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using SimpleDocumentGenerator.Core;

namespace SimpleDocumentGenerator.Forms
{
    static class Program
    {
        private const string LogsFolderName = "logs";
        private const string LogFileName = "GUI-.log";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NETCOREAPP3_1
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string currentDirectory = AppContext.BaseDirectory;

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(loggingBuilder =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .MinimumLevel.Verbose()
                        .WriteTo.File(Path.Combine(currentDirectory, LogsFolderName, LogFileName), LogEventLevel.Information,
                            @"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}: ({SourceContext}) [{Level}] {Message}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                        .CreateLogger();

                    loggingBuilder.AddSerilog();
                })
                .Build();

            var hostServices = host.Services;
            var mainForm = hostServices.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }

        private static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection serviceCollection)
        {
            var applicationSettings = new ApplicationSettings();

            hostBuilderContext.Configuration.GetSection(nameof(ApplicationSettings)).Bind(applicationSettings, options => options.BindNonPublicProperties = true);

            var googleSettings = hostBuilderContext.Configuration.GetSection("ApplicationSettings:GoogleSettings").Get<GoogleSettings>(options => options.BindNonPublicProperties = true);

            //serviceCollection.Configure<GoogleSettings>(hostBuilderContext.Configuration.GetSection($"{nameof(ApplicationSettings)}:{nameof(GoogleSettings)}")); // Don't make core library require IOptions<>

            serviceCollection.AddTransient(provider => googleSettings);
            serviceCollection.AddTransient<FileMaker>();

            serviceCollection.AddSingleton<MainForm>();
            serviceCollection.AddSingleton<ImageUtility>(); // Singleton to keep Http client alive to not consume sockets
        }
    }
}
