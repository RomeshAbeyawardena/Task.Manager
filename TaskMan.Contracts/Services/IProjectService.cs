using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface IProjectService
    {
        Task<Project> GetProject(string projectName, CancellationToken cancellationToken);
        Task<Project> Save(Project project, bool v, CancellationToken cancellationToken);
        Task<Project> GetProject(int projectId, CancellationToken cancellationToken);
    }
}
