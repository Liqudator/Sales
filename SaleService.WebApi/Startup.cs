using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Midway.Common.Extensions;
using Midway.Common.Ioc.Autofac.Managers;
using Midway.Common.Ioc.Autofac.NLog.Modules;
using Midway.Common.Ioc.Domain;
using Midway.Common.Logs.Domain;
using Midway.Common.Logs.NLog.Domain;
using System;
using System.Linq;
using System.Reflection;

namespace Sales.WebApi
{
    /// <summary>
    /// Класс, содержащий настройки служб и конвеер запросов приложения.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Настройка служб приложения.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var logger = new NLogLogger();

            logger.Info("Настройка версионирования API.");
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            logger.Info("Настройка контроллеров.");
            services.AddMvc().AddControllersAsServices();

            logger.Info("Регистрация сервисов в IoC-контейнере.");
            var container = new ContainerManager();
            container.Populate(services);

            container.RegisterType<Midway.Common.Mapping.AutoMapper.Services.MappingService>();
            container.RegisterAssemblyOf<Sales.AssembleRef>();
            container.RegisterAssemblyOf<Data.AssemblyRef>();
            container.RegisterAssemblyOf<AssemblyRef>();

            logger.Info("Регистрация контроллеров в IoC-контейнере.");
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Controller).IsAssignableFrom(t))
                .ForEach(t => container.RegisterType(InstanceScope.Transient, t, t));

            logger.Info("Регистрация логгера в IoC-контейнере.");
            container.RegisterType(InstanceScope.Transient, typeof(NLogLogger), typeof(ILogger));
            container.RegisterModule<NLogModule>();

            logger.Info("Инициализация IoC-контейнера.");
            container.Init();

            var serviceProvider = container.GetServiceProvider();
            logger.Info("Завершена настройка служб.");
            return serviceProvider;
        }

        /// <summary>
        /// Настройка конвеера запросов приложения.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env">Окружение.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
