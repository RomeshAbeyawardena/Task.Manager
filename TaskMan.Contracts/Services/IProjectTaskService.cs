using System;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTask> GetProjectTask(int projectId, int taskId, CancellationToken cancellationToken);
        Task<ProjectTask> Save(ProjectTask projectTask, bool saveChanges, CancellationToken cancellationToken);
        System.Threading.Tasks.Task Commit(CancellationToken cancellationToken);
    }
}
