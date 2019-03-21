using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Midway.Common.Mapping.Domain;
using Midway.Common.Mapping.Services;
using System.Collections.Generic;
using System.Linq;

namespace Sales.WebApi.Mapping
{
    /// <summary>
    /// Инициализация профилей маппинга.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class MappingInitiator : IInitializable
    {
        public IMappingService MappingService { get; set; }
        public IEnumerable<IMappingProfile> MappingProfiles { get; set; }

        public void Init()
            => MappingService.InitProfiles(MappingProfiles.ToArray());
    }
}
