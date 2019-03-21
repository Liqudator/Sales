using Sales.Domain;
using System.Collections.Generic;

namespace Sales.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с покупателями.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Создать нового покупателя.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <returns>Созданный покупатель.</returns>
        Customer Create(Customer customer);

        /// <summary>
        /// Получить покупателя из БД по его ИД.
        /// </summary>
        /// <param name="id">ИД покупателя.</param>
        /// <returns>Покупатель.</returns>
        Customer Get(int id);

        /// <summary>
        /// Получить всех покупателей.
        /// </summary>
        /// <returns>Коллекция покупателей.</returns>
        List<Customer> GetAll();

        /// <summary>
        /// Изменить информацию о покупателе.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <param name="id">ИД покупателя.</param>
        /// <returns>Измененный покупатель.</returns>
        Customer Update(Customer customer, int id);

        /// <summary>
        /// Удалить покупателя по его ИД.
        /// </summary>
        /// <param name="id">ИД покупателя.</param>
        void Delete(int id);
    }
}
