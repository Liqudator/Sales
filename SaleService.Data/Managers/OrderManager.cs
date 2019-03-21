using Microsoft.EntityFrameworkCore;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Services;
using Sales.Data.Contexts;
using Sales.Domain;
using Sales.Managers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Sales.Data.Managers
{
    /// <summary>
    /// Менеджер для работы с данными типа заказ.
    /// </summary>
    [InstanceScope(InstanceScope.PerLifetimeScope)]
    public class OrderManager : BaseManager<OrderContext, Order>, IOrderManager
    {
        public IMappingService MappingService { get; set; }
        public ICustomerManager CustomerManager { get; set; }
        public ISellerManager SellerManager { get; set; }

        public OrderContext OrderContext { get; set; }

        /// <summary>
        /// Создать заказ в БД.
        /// </summary>
        /// <param name="order">Заказ.</param>
        /// <param name="customerId">ИД покупателя.</param>
        /// <param name="sellerId">ИД продавца.</param>
        /// <returns>Созданный заказ.</returns>
        public Order Create(Order order, int customerId, int sellerId)
        {
            if (CustomerManager.Get(customerId).City !=
                SellerManager.Get(sellerId).City)
            {
                throw new ArgumentException();
            }

            var result = OrderContext.Orders.Add(order);
            OrderContext.SaveChanges();

            return result.Entity;
        }

        /// <summary>
        /// Получить заказы по определенному городу.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Коллекция заказов.</returns>
        public List<Order> GetByCity(string city)
        {
            var result = new List<Order>();

            SqlParameter param = new SqlParameter("@city", city);
            var orders = OrderContext.Orders.FromSql("GetOrderByCity @city", param).ToList();
            foreach(var ord in orders)
            {
                result.Add(ord);
            }

            return result;
        }

        /// <summary>
        /// Получить заказы по указанной дате.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Коллекция заказов.</returns>
        public List<Order> GetByDate(DateTime date)
        {
            var result = new List<Order>();
            
            foreach(var order in OrderContext.Orders)
            {
                if (order.OrderDate != date)
                {
                    continue;
                }

                result.Add(order);
            }

            return result;
        }
    }
}
