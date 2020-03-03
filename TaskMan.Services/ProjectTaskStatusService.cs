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
    public class ProjectTaskStatusService : IProjectTaskStatusService
    {
        public Task<ProjectTaskStatus> GetCurrentStatus(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTaskStatus> Save(ProjectTaskStatus projectTaskStatus, bool saveChanges, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
