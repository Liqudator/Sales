using Sales.Domain;
using System.Collections.Generic;

namespace Sales.Tests.Domain
{
    /// <summary>
    /// Класс, содержащий данные продавцов.
    /// </summary>
    public class SellerServiceTestHelper
    {
        public static List<Seller> GetSellerTestContext()
        {
            var sellers = new List<Seller>
            {
                new Seller
                {
                    Id = 1,
                    SecondName = "Покупаев",
                    FirstName = "Все",
                    MiddleName = "Олинович",
                    City = "Москва",
                    Comission = 10
                },
                new Seller
                {
                    Id = 2,
                    SecondName = "Диванов",
                    FirstName = "Диван",
                    MiddleName = "Диванович",
                    City = "Ижевск",
                    Comission = 5
                },
                new Seller
                {
                    Id = 3,
                    SecondName = "Автоматов",
                    FirstName = "Калаш",
                    MiddleName = "Тимофеевич",
                    City = "Белгород",
                    Comission = 1
                },
                new Seller
                {
                    Id = 4,
                    SecondName = "Вах",
                    FirstName = "Шах",
                    MiddleName = "Мат",
                    City = "Воркута",
                    Comission = 8
                },
                new Seller
                {
                    Id = 5,
                    SecondName = "Бахов",
                    FirstName = "Орган",
                    MiddleName = "Дуевич",
                    City = "Дамаск",
                    Comission = 2
                },
                new Seller
                {
                    Id = 6,
                    SecondName = "Асланов",
                    FirstName = "Шухрат",
                    MiddleName = "Гафарович",
                    City = "Грозный",
                    Comission = 5
                }
            };
            return sellers;
        }
    }
}
