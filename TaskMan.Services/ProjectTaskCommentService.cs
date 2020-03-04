using DNI.Shared.Contracts;
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
    public class ProjectTaskCommentService : IProjectTaskCommentService
    {
        private readonly IRepository<ProjectTaskComment>  _projectTaskCommentRepository;
        public async Task<ProjectTaskComment> Save(ProjectTaskComment projectTaskComment, bool saveChanges, CancellationToken cancellationToken)
        {
            return await _projectTaskCommentRepository
                .SaveChanges(projectTaskComment, saveChanges, true, cancellationToken);
        }

        public ProjectTaskCommentService(IRepository<ProjectTaskComment> projectTaskCommentRepository)
        {
            _projectTaskCommentRepository = projectTaskCommentRepository;
        }
    }
}
