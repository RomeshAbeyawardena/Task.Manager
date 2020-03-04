using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Providers
{
    public interface ITaskManCacheProvider
    {
        Task<IEnumerable<Status>> GetStatuses(CancellationToken cancellationToken);
    }
}
