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
        private readonly IRepository<Status> _statusRepository;

        public async Task<IEnumerable<Status>> GetStatuses(CancellationToken cancellationToken)
        {
            var query = from status in _statusRepository.Query(enableTracking: false)
                   select status;

            return await _statusRepository
                .For(query)
                .ToArrayAsync(cancellationToken);
        }

        public Status GetStatus(IEnumerable<Status> statuses, string statusText)
        {
            return statuses.FirstOrDefault(status => status.Name == statusText);
        }

        public async Task<int> GetMaxIdValue(CancellationToken cancellationToken)
        {
            var query = _statusRepository.Query().OrderBy(status => status.Id);
            return await _statusRepository.For(query)
                .ToMaxAsync(status => status.Id, cancellationToken);
        }

        public StatusService(IRepository<Status> statusRepository)
        {
            _statusRepository = statusRepository;
        }
    }
}
