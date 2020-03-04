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
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;

        public async Task<Project> GetProject(string projectName, CancellationToken cancellationToken)
        {
            var query = _projectRepository.Query(project => project.Name == projectName);

            return await _projectRepository.For(query).ToSingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Project> GetProject(int projectId, CancellationToken cancellationToken)
        {
            return await _projectRepository.Find(false, cancellationToken, projectId);
        }

        public async Task<Project> Save(Project project, bool saveChanges, CancellationToken cancellationToken)
        {
            return await _projectRepository.SaveChanges(project, saveChanges, true, cancellationToken);
        }

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
