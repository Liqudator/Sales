using Microsoft.AspNetCore.Mvc;
using Midway.Common.Mapping.Services;
using Sales.WebApi.Models;
using Sales.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    /// <summary>
    /// Методы для работы с покупателями.
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{ver:apiVersion}/customer")]
    public class CustomerController : Controller
    { 
        public IMappingService MappingService { get; set; }
        public ICustomerService CustomerService { get; set; }

        /// <summary>
        /// Получить всех покупателей.
        /// </summary>
        /// <returns>Колекция покупателей.</returns>
        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            return await Task.Run(() =>
                MappingService.Map<List<Customer>>(CustomerService.GetAll()));
        }

        /// <summary>
        /// Получить покупателя по его ИД.
        /// </summary>
        /// <param name="id">ИД покупателя.</param>
        /// <returns>Покупатель.</returns>
        [HttpGet("{id}")]
        public async Task<Customer> Get([FromBody] int id)
        {
            return await Task.Run(() =>
                MappingService.Map<Customer>(CustomerService.Get(id)));
        }

        /// <summary>
        /// Создать нового покупателя.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <returns>Созданный покупатель.</returns>
        [HttpPost]
        public async Task<Customer> CreateCustomer([FromBody] Customer customer)
        { 
            return await Task.Run(() =>
            {
                var temp = MappingService.Map<Domain.Customer>(customer);
                var result = MappingService.Map<Customer>(CustomerService.Create(temp));

                return result;
            });
        }

        /// <summary>
        /// Удалить покупателя.
        /// </summary>
        /// <param name="id">ИД покупателя.</param>
        /// <returns>Пусто.</returns>
        [HttpDelete("{id}")]
        public async Task Delete([FromBody] int id)
        {
            await Task.Run(() => CustomerService.Delete(id));
        }

        /// <summary>
        /// Изменить покупателя.
        /// </summary>
        /// <param name="id">ИД покупателя.</param>
        /// <param name="customer">Покупатель.</param>
        /// <returns>Измененный покупатель.</returns>
        [HttpPut("{id}")]
        public async Task<Customer> Update(int id, [FromBody] Customer customer)
        {
            return await Task.Run(() =>
            {
                if(id == customer.Id)
                {
                    var temp = MappingService.Map<Domain.Customer>(customer);
                    var result = MappingService.Map<Customer>(CustomerService.Update(temp));
                    return result;
                }

                return customer;
            });
        }
    }
}
