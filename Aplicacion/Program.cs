using ApplicationBusiness;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Aplicacion
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuraci�n de servicios
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            // Configurar la inicializaci�n de la aplicaci�n
            ApplicationConfiguration.Initialize();

            // Resolver el formulario principal e iniciar la aplicaci�n
            var mainForm = serviceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormMain());

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registro de dependencias
            services.AddTransient<AudioDownloader>();
            services.AddTransient<VideoDownloader>();
            services.AddTransient<VideoObtenerDatos>();
            services.AddTransient<IAudioRepository, AudioRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormDescargarAudio>();
            services.AddTransient<FormDescargarVideo>();
        }
    }
}