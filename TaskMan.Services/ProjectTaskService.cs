using DNI.Shared.Contracts;
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
        private readonly IRepository<ProjectTask> _projectTaskRepository;

        public async System.Threading.Tasks.Task Commit(CancellationToken cancellationToken)
        {
            await _projectTaskRepository.Commit(cancellationToken);
        }

        public async Task<ProjectTask> GetProjectTask(int projectId, int taskId, CancellationToken cancellationToken)
        {
            var query = _projectTaskRepository
                .Query(pT => pT.ProjectId == projectId && pT.TaskId == taskId);

                return await _projectTaskRepository.For(query)
                    .ToSingleOrDefaultAsync(cancellationToken);
        }

        public async Task<ProjectTask> Save(ProjectTask projectTask, bool saveChanges, CancellationToken cancellationToken)
        {
            return await _projectTaskRepository
                .SaveChanges(projectTask, saveChanges, true, cancellationToken);
        }

        public ProjectTaskService(IRepository<ProjectTask> projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }
    }
}
