using AutoMapper;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Domain;
using Sales.WebApi.Models;

namespace Sales.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппинга продавцов.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class SellerMappingProfile : Profile, IMappingProfile
    {
        /// <summary>
        /// Инициализировать экземпляр маппинга для продавца. 
        /// </summary>
        public SellerMappingProfile()
        {
            CreateMap<Seller, Domain.Seller>();
        }
    }
}
