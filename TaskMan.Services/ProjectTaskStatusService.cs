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
    public class ProjectTaskStatusService : IProjectTaskStatusService
    {
        private readonly IRepository<ProjectTaskStatus> _projectTaskStatusRepository;

        public async Task<ProjectTaskStatus> GetCurrentStatus(int projectTaskId, CancellationToken cancellationToken)
        {
            var query = from projectTaskStatus in _projectTaskStatusRepository
                        .Query(projectTaskStatus => projectTaskStatus.ProjectTaskId == projectTaskId, false)
                        orderby projectTaskStatus.Modified, projectTaskStatus.Created descending
                        select projectTaskStatus;

            return await query.FirstOrDefaultAsync();

        }

        public async Task<ProjectTaskStatus> Save(ProjectTaskStatus projectTaskStatus, bool saveChanges, CancellationToken cancellationToken)
        {
            return await _projectTaskStatusRepository
                .SaveChanges(projectTaskStatus, saveChanges, true, cancellationToken);
        }

        public ProjectTaskStatusService(IRepository<ProjectTaskStatus> projectTaskStatusRepository)
        {
            _projectTaskStatusRepository = projectTaskStatusRepository;
        }
    }
}
