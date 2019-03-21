using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Logs.Domain;
using Sales.Domain;
using Sales.Managers;
using Sales.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Data.Services
{
    /// <summary>
    /// Сервис для работы с покупателями.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class CustomerService : ICustomerService
    {
        public ILogger Logger { get; set; }
        public ICustomerManager CustomerManager { get; set; }

        public Customer Create(Customer customer)
        {
            Logger.Info("Создание покупателя.");
            var result = CustomerManager.Create(customer);
            Logger.Info("Покупатель создан.");

            return result;
        }

        public void Delete(int id)
        {
            Logger.Info("Удаление покупателя.");
            CustomerManager.Delete(id);
        }

        public Customer Get(int id)
        {
            Logger.Info("Получение покупателя по его ИД.");
            var customer = CustomerManager.Get(id);
            Logger.Info("Покупатель получен.");

            return customer;
        }

        public List<Customer> GetAll()
        {
            Logger.Info("Получение всех покупателей.");
            return CustomerManager.GetAll().ToList();
        }

        public Customer Update(Customer customer, int id)
        {
            Logger.Info("Изменение покупателя.");
            var result = CustomerManager.Update(customer, id);
            Logger.Info("Покупатель изменен.");

            return result;
        }
    }
}
