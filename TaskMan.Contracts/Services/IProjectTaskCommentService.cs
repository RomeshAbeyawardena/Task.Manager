using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectTaskCommentService
    {
        Task<ProjectTaskComment> Save(ProjectTaskComment projectTaskComment, bool saveChanges, CancellationToken cancellationToken);
    }
}
