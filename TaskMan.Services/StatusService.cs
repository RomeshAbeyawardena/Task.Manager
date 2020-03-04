using DNI.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Contracts.Services;
using TaskMan.Domains.Data;

namespace TaskMan.Services
{
    public class StatusService : IStatusService
    {
        private IRepository<Status> _statusRepository;

        public async Task<IEnumerable<Status>> GetStatuses(CancellationToken cancellationToken)
        {
            var query = from status in _statusRepository.Query(enableTracking: false)
                   select status;

            return await query.ToArrayAsync();
        }

        public Status GetStatus(IEnumerable<Status> statuses, string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public StatusService(IRepository<Status> statusRepository)
        {
            _statusRepository = statusRepository;
        }
    }
}
