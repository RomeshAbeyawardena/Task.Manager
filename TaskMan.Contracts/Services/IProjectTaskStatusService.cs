using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectTaskStatusService
    {
        Task<ProjectTaskStatus> GetCurrentStatus(int id, CancellationToken cancellationToken);
        Task<ProjectTaskStatus> Save(ProjectTaskStatus projectTaskStatus, bool saveChanges, CancellationToken cancellationToken);
    }
}
