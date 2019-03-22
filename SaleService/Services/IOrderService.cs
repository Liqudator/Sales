using System;
using System.Collections.Generic;
using Sales.Domain;

namespace Sales.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с заказом.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Создать новый заказ.
        /// </summary>
        /// <param name="order">Заказ.</param>
        /// <param name="customerId">ИД покупателя.</param>
        /// <param name="sellerId">ИД продавца.</param>
        /// <returns>Созданный заказ.</returns>
        Order Create(Order order, int customerId, int sellerId);

        /// <summary>
        /// Получить заказ из БД по его ИД.
        /// </summary>
        /// <param name="id">ИД заказа.</param>
        /// <returns>Заказ.</returns>
        Order Get(int id);

        /// <summary>
        /// Получить все заказы.
        /// </summary>
        /// <returns>Коллекция заказов.</returns>
        List<Order> GetAll();
        
        /// <summary>
        /// Получить все заказы по указанной дате.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Коллекция заказов.</returns>
        List<Order> GetAllByDate(DateTime date);

        /// <summary>
        /// Получить заказы по определенному городу
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Коллекция заказов.</returns>
        List<Order> GetAllByCity(string city);

        /// <summary>
        /// Изменить информацию о заказе.
        /// </summary>
        /// <param name="order">Заказ.</param>
        /// <param name="id">ИД заказа.</param>
        /// <returns>Измененный заказ.</returns>
        Order Update(Order order, int id);

        /// <summary>
        /// Удалить заказ по его ИД.
        /// </summary>
        /// <param name="id">ИД заказа.</param>
        void DeleteOrder(int id);

        /// <summary>
        /// Удалить заказ старше года.
        /// </summary>
        void DeleteOlderOneYear();

        /// <summary>
        /// Удалить историю заказов старше года.
        /// </summary>
        void DeleteOrderHistoryOlderOneYear();
    }
}
