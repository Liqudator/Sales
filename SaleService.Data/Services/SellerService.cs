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
    /// Сервис для работы с продавцами.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class SellerService : ISellerService
    {
        public ILogger Logger { get; set; }
        public ISellerManager SellerManager { get; set; }

        public Seller Create(Seller seller)
        {
            Logger.Info("Создание продавца.");
            var result = SellerManager.Create(seller);
            Logger.Info("Продавец создан.");

            return result;
        }

        public void Delete(int id)
        {
            Logger.Info("Удаление продавца.");
            SellerManager.Delete(id);
        }

        public Seller Get(int id)
        {
            Logger.Info("Получение продавца по его ИД.");
            var seller = SellerManager.Get(id);
            Logger.Info("Продавец получен.");

            return seller;
        }

        public List<Seller> GetAll()
        {
            Logger.Info("Получение всех продавцов.");
            return SellerManager.GetAll().ToList();
        }

        public Seller Update(Seller seller)
        {
            Logger.Info("Изменение продавца.");
            var result = SellerManager.Update(seller);
            Logger.Info("Продавец изменен.");

            return result;
        }
    }
}
