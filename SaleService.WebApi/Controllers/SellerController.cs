using Microsoft.AspNetCore.Mvc;
using Midway.Common.Mapping.Services;
using Sales.WebApi.Models;
using Sales.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.WebApi.Controllers
{
    /// <summary>
    /// Методы для работы с продавцами.
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{ver:apiVersion}/seller")]
    public class SellerController : Controller
    {
        public IMappingService MappingService { get; set; }
        public ISellerService SellerService { get; set; }

        /// <summary>
        /// Получить всех продавцов.
        /// </summary>
        /// <returns>Коллекция продавцов.</returns>
        [HttpGet]
        public async Task<List<Seller>> GetAll()
        {
            return await Task.Run(() =>
                MappingService.Map<List<Seller>>(SellerService.GetAll()));
        }

        /// <summary>
        /// Получить продавца по его ИД.
        /// </summary>
        /// <param name="id">ИД продавца.</param>
        /// <returns>Продавец.</returns>
        [HttpGet("{id}")]
        public async Task<Seller> Get(int id)
        {
            return await Task.Run(() =>
                MappingService.Map<Seller>(SellerService.Get(id)));
        }

        /// <summary>
        /// Создать нового продавца.
        /// </summary>
        /// <param name="seller">Продавец.</param>
        /// <returns>Созданный продавец.</returns>
        [HttpPost]
        public async Task<Seller> CreateSeller(Seller seller)
        {
            return await Task.Run(() =>
            {
                var temp = MappingService.Map<Domain.Seller>(seller);
                var result = MappingService.Map<Seller>(SellerService.Create(temp));

                return result;
            });
        }

        /// <summary>
        /// Удалить продавца.
        /// </summary>
        /// <param name="id">ИД продавца.</param>
        /// <returns>Пусто.</returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => SellerService.Delete(id));
        }

        /// <summary>
        /// Изменить продавца.
        /// </summary>
        /// <param name="seller">Продавец.</param>
        /// <param name="id">ИД продавца.</param>
        /// <returns>Измененный продавец.</returns>
        [HttpPut("{id}")]
        public async Task<Seller> Update([FromBody] Seller seller, int id)
        {
            return await Task.Run(() =>
            {
                var temp = MappingService.Map<Seller>(seller);
                var tempResult = MappingService.Map<Domain.Seller>(SellerService.Get(id));
                tempResult.Id = temp.Id;
                tempResult.SecondName = temp.SecondName;
                tempResult.FirstName = temp.FirstName;
                tempResult.MiddleName = temp.MiddleName;
                tempResult.City = temp.City;
                tempResult.Comission = temp.Comission;
                var result = MappingService.Map<Seller>(SellerService.Update(tempResult, id));

                return result;
            });
        }
    }
}
