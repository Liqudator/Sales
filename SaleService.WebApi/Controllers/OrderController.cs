using Microsoft.AspNetCore.Mvc;
using Midway.Common.Mapping.Services;
using Sales.Services;
using Sales.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    /// <summary>
    /// Методы для работы с заказами.
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{ver:apiVersion}/order")]
    public class OrderController : Controller
    {
        public IMappingService MappingService { get; set; }
        public IOrderService OrderService { get; set; }

        /// <summary>
        /// Получить все заказы.
        /// </summary>
        /// <returns>Коллекция заказов.</returns>
        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await Task.Run(() =>
                MappingService.Map<List<Order>>(OrderService.GetAll()));
        }

        /// <summary>
        /// Получить заказ по его ИД.
        /// </summary>
        /// <param name="id">ИД заказа.</param>
        /// <returns>Заказ.</returns>
        [HttpGet("{id}")]
        public async Task<Order> Get([FromBody] int id)
        {
            return await Task.Run(() =>
                MappingService.Map<Order>(OrderService.Get(id)));
        }

        /// <summary>
        /// Найти все заказы по определенному городу.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Коллекция заказов.</returns>
        [HttpGet("{city}")]
        public async Task<List<Order>> GetByCity([FromBody] string city)
        {
            return await Task.Run(() =>
                MappingService.Map<List<Order>>(OrderService.GetAllByCity(city)));
        }

        /// <summary>
        /// Найти все заказы по определенной дате.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Коллекция заказов.</returns>
        [HttpGet("{date}")]
        public async Task<List<Order>> GetByDate([FromBody] DateTime date)
        {
            return await Task.Run(() =>
                MappingService.Map<List<Order>>(OrderService.GetAllByDate(date)));
        }

        /// <summary>
        /// Создать новый заказ.
        /// </summary>
        /// <remarks>
        /// Продавец и покупатель должны быть из одного города.
        /// </remarks>
        /// <param name="order">Заказ.</param>
        /// <param name="customerId">ИД покупателя.</param>
        /// <param name="sellerId">ИД заказчика.</param>
        /// <returns>Созданный заказ.</returns>
        [HttpPost]
        public async Task<Order> CreateCustomer([FromBody] Order order, 
            [FromBody] int customerId, [FromBody] int sellerId)
        {
            return await Task.Run(() =>
            {
                var temp = MappingService.Map<Domain.Order>(order);
                var result = MappingService.Map<Order>(OrderService.Create(temp, customerId, sellerId));

                return result;
            });
        }

        /// <summary>
        /// Удалить заказ.
        /// </summary>
        /// <param name="id">ИД заказа.</param>
        /// <returns>Пусто.</returns>
        [HttpDelete("{id}")]
        public async Task Delete([FromBody] int id)
        {
            await Task.Run(() => OrderService.DeleteOrder(id));
        }

        /// <summary>
        /// Изменить заказ.
        /// </summary>
        /// <param name="id">ИД заказа.</param>
        /// <param name="order">Заказ.</param>
        /// <returns>Измененный заказ.</returns>
        [HttpPut("{id}")]
        public async Task<Order> Update(int id, [FromBody] Order order)
        {
            return await Task.Run(() =>
            {
                if (id == order.Id)
                {
                    var temp = MappingService.Map<Domain.Order>(order);
                    var result = MappingService.Map<Order>(OrderService.Update(temp));
                    return result;
                }

                return order;
            });
        }
    }
}
