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
    /// Тесты класса <see cref="OrderService"/>.
    /// </summary>
    [TestFixture]
    public class OrderServiceTests : SalesTestBase
    {
        public OrderService OrderService { get; set; }
        public Mock<IOrderManager> OrderManagerMock { get; set; }

        public List<Order> Orders { get; set; }

        /// <summary>
        /// Инициализация контекста тестов. 
        /// </summary>
        public override void ClassInitialize()
        {
            base.ClassInitialize();
            Orders = OrderServiceTestHelper.GetOrderTestContext();
        }

        /// <summary>
        /// Регистрация типа менеджера заказа.
        /// </summary>
        public override void RegisterTypes()
        {
            base.RegisterTypes();
            OrderManagerMock = new Mock<IOrderManager>();
            ContainerManager.RegisterInstance(InstanceScope.Singleton, OrderManagerMock.Object, typeof(IOrderManager));
        }

        [Test]
        [Description("Тест получения заказа по его ИД.")]
        [Category("Unit")]
        public void OrderService_Get()
        {
            // Given. 
            var order = Orders[0].Id;
            /*OrderManagerMock
                .Setup(e => e.Get(Orders[0].Id))
                .Returns(Orders[0]);*/

            // When.
            OrderService.Get(order);

            // Then.
            OrderManagerMock.Verify(e => e.Get(It.Is<int>(s => s == order)), Times.Once);
        }

        [Test]
        [Description("Тест получения всех заказов.")]
        [Category("Unit")]
        public void OrderService_GetAll()
        {
            // Given.
            OrderManagerMock
                .Setup(e => e.GetAll())
                .Returns(Orders);

            // When.
            //OrderService.GetAll();
            var result = OrderService.GetAll();

            // Then.
            //OrderManagerMock.Verify(e => e.GetAll(), Times.Once);
            Assert.AreEqual(result, Orders);
        }

        [Test]
        [Description("Тест создания заказа.")]
        [Category("Unit")]
        public void OrderService_Create()
        {
            // Given.
            var order = Orders[0];
            var customerId = Orders[0].CustomerId;
            var sellerId = Orders[0].SellerId;

            // When.
            OrderService.Create(order, customerId, sellerId);

            // Then.
            OrderManagerMock.Verify(e => e.Create(It.Is<Order>(c => c == order), customerId, sellerId), Times.Once);
        }

        [Test]
        [Description("Тест изменение заказа.")]
        [Category("Unit")]
        public void OrderService_Update()
        {
            // Given.
            int id = 0;
            var order = Orders[id];

            // When.
            OrderService.Update(order);

            // Then.
            OrderManagerMock.Verify(e => e.Update(It.Is<Order>(c => c == order)), Times.Once);
        }

        [Test]
        [Description("Тест удаления заказа старше 1 года.")]
        [Category("Unit")]
        public void OrderService_DeleteOrderOlderOneYear()
        {
            // When.
            OrderService.DeleteOrderOlderOneYear();

            // Then.
            OrderManagerMock.Verify(e => e.DeleteOrderOlderOneYear(), Times.Once);
        }
    }
}
