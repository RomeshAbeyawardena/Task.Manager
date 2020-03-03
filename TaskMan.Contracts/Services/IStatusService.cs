using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMan.Contracts.Services
{
    public interface IStatusService
    {
        Task<Domains.Data.Status> GetStatus(string status, CancellationToken cancellationToken);
    }
}
