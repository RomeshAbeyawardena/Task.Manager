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
        public Task<ProjectTaskComment> Save(ProjectTaskComment projectTaskComment, bool saveChanges, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
