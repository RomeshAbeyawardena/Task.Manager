using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IStatusService
    {
        Task<int> GetMaxIdValue(CancellationToken cancellationToken);
        Status GetStatus(IEnumerable<Status> statuses, string status);
        Task<IEnumerable<Status>> GetStatuses(CancellationToken cancellationToken);
    }
}
