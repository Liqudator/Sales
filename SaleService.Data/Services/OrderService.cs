using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Logs.Domain;
using Sales.Domain;
using Sales.Managers;
using Sales.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Data.Services
{
    /// <summary>
    /// Сервис для работы с заказами.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class OrderService : IOrderService
    {
        public ILogger Logger { get; set; }
        public IOrderManager OrderManager { get; set; }

        public Order Create(Order order, int customerId, int sellerId)
        {
            Logger.Info("Формирование заказа.");
            var result = OrderManager.Create(order, customerId, sellerId);
            Logger.Info("Заказ сформирован.");

            return result;
        }

        public void DeleteOrder(int id)
        {
            Logger.Info("Удаление заказа по его ИД.");
            OrderManager.Delete(id);
        }

        public Order Get(int id)
        {
            Logger.Info("Получение заказа по его ИД.");
            var result = OrderManager.Get(id);
            Logger.Info("Заказ получен.");

            return result;
        }

        public List<Order> GetAll()
        {
            Logger.Info("Получение всех заказов.");
            return OrderManager.GetAll().ToList();
        }

        public List<Order> GetAllByDate(DateTime date)
        {
            Logger.Info("Получение заказов по указанной дате.");
            var result = OrderManager.GetByDate(date);
            Logger.Info("Заказы получены.");

            return result;
        }

        public Order Update(Order order, int id)
        {
            Logger.Info("Изменение заказа.");
            var result = OrderManager.Update(order, id);
            Logger.Info("Заказ изменен.");

            return result;
        }

        public List<Order> GetAllByCity(string city)
        {
            Logger.Info("Получение заказов по указанному городу.");
            var result = OrderManager.GetByCity(city);
            Logger.Info("Заказы получены.");

            return result;
        }

        public void DeleteOlderOneYear()
        {
            Logger.Info("Удаление заказов старше 1 года.");
            OrderManager.DeleteOlderOneYear();
        }

        public void DeleteOrderHistoryOlderOneYear()
        {
            Logger.Info("Удаление истории заказов старше 1 года.");
            OrderManager.DeleteOrderHistory();
        }
    }
}
