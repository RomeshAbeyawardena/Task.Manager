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
        public Task<Status> GetStatus(string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
