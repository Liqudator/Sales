using System;
using System.Collections.Generic;
using Sales.Domain;

namespace Sales.Managers
{
    /// <summary>
    /// Интерфейс менеджера для работы с заказом.
    /// </summary>
    public interface IOrderManager : IGenericManager<Order>
    {
        /// <summary>
        /// Создать заказ. Покупатель и продавец должны быть из одного города.
        /// </summary>
        /// <param name="order">Заказ.</param>
        /// <param name="customerId">ИД покупателя.</param>
        /// <param name="sellerId">ИД продавца.</param>
        /// <returns>Созданный заказ.</returns>
        Order Create(Order order, int customerId, int sellerId);

        /// <summary>
        /// Получить запись по городу.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Коллекция полученных заказов.</returns>
        List<Order> GetByCity(string city);

        /// <summary>
        /// Получить заказы по указанной дате.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Коллекция заказов.</returns>
        List<Order> GetByDate(DateTime date);

        /// <summary>
        /// Удалить заказ старше 1 года.
        /// </summary>
        void DeleteOlderOneYear();

        /// <summary>
        /// Удалить историю заказов.
        /// </summary>
        void DeleteOrderHistory();
    }
}
