using Sales.Domain;
using System.Collections.Generic;

namespace Sales.Tests.Domain
{
    /// <summary>
    /// Класс, содержащий данные заказов.
    /// </summary>
    public class OrderServiceTestHelper
    {
        public static List<Order> GetOrderTestContext()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Description = "Заказ пиццы",
                    Sum = 1300,
                    OrderDate = new System.DateTime(2018, 3, 23, 0, 0, 0),
                    CustomerId = 6,
                    SellerId = 1
                }
            };
            return orders;
        }
    }
}
