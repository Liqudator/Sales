using Midway.Common.Ioc.Domain;
using Moq;
using NUnit.Framework;
using Sales.Domain;
using Sales.Data.Services;
using Sales.Managers;
using Sales.Tests.Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sales.Tests.Services
{
    /// <summary>
    /// Тесты класса <see cref="CustomerService"/>.
    /// </summary>
    [TestFixture]
    public class CustomerServiceTests : SalesTestBase
    {
        public CustomerService CustomerService { get; set; }
        public Mock<ICustomerManager> CustomerManager { get; set; }

        public List<Customer> Customers { get; set; }

        /// <summary>
        /// Инициализация контекста тестов. 
        /// </summary>
        public override void ClassInitialize()
        {
            base.ClassInitialize();
            Customers = CustomerServiceTestHelper.GetCustomerTestContext();
        }

        /// <summary>
        /// Регистрация типа менеджера покупателя.
        /// </summary>
        public override void RegisterTypes()
        {
            base.RegisterTypes();
            CustomerManager = new Mock<ICustomerManager>();
            ContainerManager.RegisterInstance(InstanceScope.Singleton, CustomerManager.Object, typeof(ICustomerManager));
        }

        [Test]
        [Description("Тест получения покупателя по его ИД.")]
        [Category("Unit")]
        public void CustomerService_Get()
        {
            // Given. 
            var customer = Customers[0].Id;

            // When.
            CustomerService.Get(customer);

            // Then.
            CustomerManager.Verify(e => e.Get(It.Is<int>(s => s == customer)), Times.Once);
        }

        [Test]
        [Description("Тест получения всех покупателей.")]
        [Category("Unit")]
        public void CustomerService_GetAll()
        {
            // When.
            CustomerService.GetAll();

            // Then.
            CustomerManager.Verify(e => e.GetAll(), Times.Once);
        }
    }
}
