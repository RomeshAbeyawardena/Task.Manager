using DNI.Shared.Contracts.Enumerations;
using DNI.Shared.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Contracts.Providers;
using TaskMan.Contracts.Services;
using TaskMan.Domains.Data;

namespace TaskMan.Services.Providers
{
    public class TaskManCacheProvider : ITaskManCacheProvider
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly IStatusService _statusService;

        public async Task<IEnumerable<Status>> GetStatuses(CancellationToken cancellationToken)
        {
            return await _cacheProvider
                .GetOrSet(CacheType.DistributedMemoryCache, CacheConstants.StatusCache, 
                async() => await _statusService.GetStatuses(cancellationToken), 
                cancellationToken);
        }

        public TaskManCacheProvider(ICacheProvider cacheProvider, IStatusService statusService)
        {
            _cacheProvider = cacheProvider;
            _statusService = statusService;
        }
    }
}
