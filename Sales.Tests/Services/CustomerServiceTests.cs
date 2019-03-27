using Midway.Common.Ioc.Domain;
using Moq;
using NUnit.Framework;
using Sales.Domain;
using Sales.Data.Services;
using Sales.Managers;
using Sales.Tests.Domain;
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
        public Mock<ICustomerManager> CustomerManagerMock { get; set; }

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
            CustomerManagerMock = new Mock<ICustomerManager>();
            ContainerManager.RegisterInstance(InstanceScope.Singleton, CustomerManagerMock.Object, typeof(ICustomerManager));
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
            CustomerManagerMock.Verify(e => e.Get(It.Is<int>(s => s == customer)), Times.Once);
        }

        [Test]
        [Description("Тест получения всех покупателей.")]
        [Category("Unit")]
        public void CustomerService_GetAll()
        {
            // When.
            CustomerService.GetAll();

            // Then.
            CustomerManagerMock.Verify(e => e.GetAll(), Times.Once);
        }

        [Test]
        [Description("Тест создания покупателя.")]
        [Category("Unit")]
        public void CustomerService_Create()
        {
            // Given.
            var customer = Customers[0];

            // When.
            CustomerService.Create(customer);

            // Then.
            CustomerManagerMock.Verify(e => e.Create(It.Is<Customer>(c => c == customer)), Times.Once);
        }

        [Test]
        [Description("Тест изменение покупателя.")]
        [Category("Unit")]
        public void CustomerService_Update()
        {
            // Given.
            int id = 1;
            var customer = Customers[id];

            // When.
            CustomerService.Update(customer);

            // Then.
            CustomerManagerMock.Verify(e => e.Update(It.Is<Customer>(c => c == customer)), Times.Once);
        }
    }
}
