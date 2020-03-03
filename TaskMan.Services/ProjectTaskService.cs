using System;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Contracts;
using TaskMan.Contracts.Services;
using TaskMan.Domains.Data;

namespace TaskMan.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        public Task<ProjectTaskStatus> GetCurrentStatus(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTask> GetProjectTask(int projectId, int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTask> Save(ProjectTask projectTask, bool saveChanges)
        {
            throw new NotImplementedException();
        }
    }
}
