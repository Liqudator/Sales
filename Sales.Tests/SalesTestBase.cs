using Autofac;
using Autofac.Core;
using Midway.Common.Ioc.Autofac.Managers;
using Midway.Common.Ioc.Autofac.NLog.Modules;
using Midway.TestFramework.NUnit.Domain;

namespace Sales.Tests
{
    /// <summary>
    /// Базовый класс для тестов.
    /// </summary>
    public class SalesTestBase : NUnitIocTestClassBase<ILifetimeScope, Parameter>
    {
        /// <summary>
        /// Создать IoC-контейнер.
        /// </summary>
        protected override void CreateContainerManager()
        {
            ContainerManager = new ContainerManager();
        }

        /// <summary>
        /// Регистрация типов в IoC-контейнере.
        /// </summary>
        public override void RegisterTypes()
        {
            base.RegisterTypes();
            ContainerManager.RegisterAssemblyOf<Sales.Data.AssemblyRef>();
            ContainerManager.RegisterModule<NLogModule>();
        }
    }
}