using System;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTask> GetProjectTask(int projectId, int taskId);
        Task<ProjectTask> Save(ProjectTask projectTask, bool saveChanges);
        Task<ProjectTaskStatus> GetCurrentStatus(int id, System.Threading.CancellationToken cancellationToken);
    }
}
