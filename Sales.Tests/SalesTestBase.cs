using Autofac;
using Autofac.Core;
using Midway.Common.Ioc.Autofac.Managers;
using Midway.Common.Ioc.Autofac.NLog.Modules;
using Midway.TestFramework.NUnit.Domain;

namespace Sales.Tests
{
    /// <summary>
    /// ������� ����� ��� ������.
    /// </summary>
    public class SalesTestBase : NUnitIocTestClassBase<ILifetimeScope, Parameter>
    {
        /// <summary>
        /// ������� IoC-���������.
        /// </summary>
        protected override void CreateContainerManager()
        {
            ContainerManager = new ContainerManager();
        }

        /// <summary>
        /// ����������� ����� � IoC-����������.
        /// </summary>
        public override void RegisterTypes()
        {
            base.RegisterTypes();
            ContainerManager.RegisterAssemblyOf<Sales.Data.AssemblyRef>();
            ContainerManager.RegisterModule<NLogModule>();
        }
    }
}