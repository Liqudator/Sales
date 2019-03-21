using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;

namespace Sales.WebApi
{
    /// <summary>
    /// Класс точки входа приложения.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа приложения.
        /// </summary>
        /// <param name="args">Аргументы приложения.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Сборка веб-узла.
        /// </summary>
        /// <param name="args">Аргументы приложения.</param>
        /// <returns>Сборщик веб-узла.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
