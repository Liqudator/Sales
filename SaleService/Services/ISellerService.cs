using Sales.Domain;
using System.Collections.Generic;

namespace Sales.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с продавцом.
    /// </summary>
    public interface ISellerService
    {
        /// <summary>
        /// Создать нового продавца.
        /// </summary>
        /// <param name="seller">Продавец.</param>
        /// <returns>Созданный продавец.</returns>
        Seller Create(Seller seller);

        /// <summary>
        /// Получить продавца из БД по его ИД.
        /// </summary>
        /// <param name="id">ИД продавца.</param>
        /// <returns>Продовец.</returns>
        Seller Get(int id);

        /// <summary>
        /// Получить всех продавцов.
        /// </summary>
        /// <returns>Коллекция продавцов.</returns>
        List<Seller> GetAll();

        /// <summary>
        /// Изменить информацию о продавце.
        /// </summary>
        /// <param name="seller">Продавец.</param>
        /// <returns>Измененный продавец.</returns>
        Seller Update(Seller seller);

        /// <summary>
        /// Удалить продавца по его ИД.
        /// </summary>
        /// <param name="id">ИД продавца.</param>
        void Delete(int id);
    }
}
