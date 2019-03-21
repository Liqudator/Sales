using AutoMapper;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Domain;
using Sales.WebApi.Models;

namespace Sales.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппинга заказов.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class OrderMappingProfile : Profile, IMappingProfile
    {
        /// <summary>
        /// Инициализировать экземпляр маппинга для заказа. 
        /// </summary>
        public OrderMappingProfile()
        {
            CreateMap<Order, Domain.Order>();
        }
    }
}