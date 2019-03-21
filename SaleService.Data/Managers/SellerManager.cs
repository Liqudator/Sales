using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Services;
using Sales.Data.Contexts;
using Sales.Domain;
using Sales.Managers;

namespace Sales.Data.Managers
{
    /// <summary>
    /// Менеджер работы с данными типа продавец.
    /// </summary>
    [InstanceScope(InstanceScope.PerLifetimeScope)]
    public class SellerManager : BaseManager<SellerContext, Seller>, ISellerManager
    {
        public IMappingService MappingService { get; set; }
    }
}
