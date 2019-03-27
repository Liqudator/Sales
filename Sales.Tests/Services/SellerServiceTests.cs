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
    public class SellerServiceTests : SalesTestBase
    {
        public SellerService SellerService { get; set; }
        public Mock<ISellerManager> SellerManagerMock { get; set; }

        public List<Seller> Sellers { get; set; }

        /// <summary>
        /// Инициализация контекста тестов. 
        /// </summary>
        public override void ClassInitialize()
        {
            base.ClassInitialize();
            Sellers = SellerServiceTestHelper.GetSellerTestContext();
        }

        /// <summary>
        /// Регистрация типа менеджера продавца.
        /// </summary>
        public override void RegisterTypes()
        {
            base.RegisterTypes();
            SellerManagerMock = new Mock<ISellerManager>();
            ContainerManager.RegisterInstance(InstanceScope.Singleton, SellerManagerMock.Object, typeof(ISellerManager));
        }

        [Test]
        [Description("Тест получения продавца по его ИД.")]
        [Category("Unit")]
        public void SellerService_Get()
        {
            // Given. 
            var seller = Sellers[0].Id;

            // When.
            SellerService.Get(seller);

            // Then.
            SellerManagerMock.Verify(e => e.Get(It.Is<int>(s => s == seller)), Times.Once);
        }

        [Test]
        [Description("Тест получения всех продавцов.")]
        [Category("Unit")]
        public void SellerService_GetAll()
        {
            // When.
            SellerService.GetAll();

            // Then.
            SellerManagerMock.Verify(e => e.GetAll(), Times.Once);
        }

        [Test]
        [Description("Тест создания продавца.")]
        [Category("Unit")]
        public void SellerService_Create()
        {
            // Given.
            var seller = Sellers[0];

            // When.
            SellerService.Create(seller);

            // Then.
            SellerManagerMock.Verify(e => e.Create(It.Is<Seller>(c => c == seller)), Times.Once);
        }

        [Test]
        [Description("Тест изменение продавца.")]
        [Category("Unit")]
        public void SellerService_Update()
        {
            // Given.
            int id = 1;
            var seller = Sellers[id];

            // When.
            SellerService.Update(seller);

            // Then.
            SellerManagerMock.Verify(e => e.Update(It.Is<Seller>(c => c == seller)), Times.Once);
        }
    }
}
