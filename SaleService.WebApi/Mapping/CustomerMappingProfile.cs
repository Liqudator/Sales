using AutoMapper;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Domain;
using Sales.WebApi.Models;

namespace Sales.WebApi.Mapping
{
    /// <summary>
    /// Профиль маппинга покупателей.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class CustomerMappingProfile : Profile, IMappingProfile 
    {
        /// <summary>
        /// Инициализировать экземпляр маппинга для покупателя. 
        /// </summary>
        public CustomerMappingProfile()
        {
            CreateMap<Customer, Domain.Customer>();
        }
    }
}
