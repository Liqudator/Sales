using Sales.Domain;
using System.Collections.Generic;

namespace Sales.Tests.Domain
{
    /// <summary>
    /// Класс, содержащий данные покупателей.
    /// </summary>
    public static class CustomerServiceTestHelper
    {
        public static List<Customer> GetCustomerTestContext()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 2,
                    SecondName = "Мирлачев",
                    FirstName = "Диван",
                    MiddleName = "Васильевич",
                    City = "Белгород"
                },
                new Customer
                {
                    Id = 3,
                    SecondName = "Вахлачев",
                    FirstName = "Пахлава",
                    MiddleName = "Сириевич",
                    City = "Дамаск"
                },
                new Customer
                {
                    Id = 4,
                    SecondName = "Пурлачев",
                    FirstName = "Вьюга",
                    MiddleName = "Морозович",
                    City = "Воркута"
                },
                new Customer
                {
                    Id = 5,
                    SecondName = "Калашников",
                    FirstName = "Автомат",
                    MiddleName = "Акакьевич",
                    City = "Ижевск"
                },
                new Customer
                {
                    Id = 6,
                    SecondName = "Торпедов",
                    FirstName = "Ракета",
                    MiddleName = "Астрономович",
                    City = "Москва"
                },
                new Customer
                {
                    Id = 7,
                    SecondName = "Арапов",
                    FirstName = "Араб",
                    MiddleName = "Альбаск",
                    City = "Грозный"
                },
                new Customer
                {
                    Id = 8,
                    SecondName = "Улюкаев",
                    FirstName = "Ворюга",
                    MiddleName = "Бестыдникович",
                    City = "Москва"
                },
                new Customer
                {
                    Id = 9,
                    SecondName = "Куклачев",
                    FirstName = "Кошик",
                    MiddleName = "Будулаевич",
                    City = "Москва"
                }
            };
            return customers;
        }
    }
}
