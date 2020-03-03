using DNI.Shared.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Contracts.Services;
using TaskMan.Domains.Data;
using TaskMan.Domains.Options;

namespace TaskMan.Services
{
    public class ProjectTaskReferenceService : IProjectTaskReferenceService
    {
        private readonly IOptions<ProjectTaskReferenceOptions> _options;
        private readonly IRepository<ProjectTaskReference> _projectTaskReferenceRepository;

        public async Task<ProjectTaskReference> Save(ProjectTaskReference projectTaskReference, 
            bool saveChanges, CancellationToken cancellationToken)
        {
            return await _projectTaskReferenceRepository
                .SaveChanges(projectTaskReference, saveChanges, true, cancellationToken);
        }

        public bool TryGetReferences(string references, out IEnumerable<ProjectTaskReference> projectTaskReferences)
        {
            var projectTaskReferenceList = new List<ProjectTaskReference>();

            var optionValue = _options.Value;
            foreach(var reference in references
                .Split(optionValue.ProjectReferenceSeparator))
            {
                var refs = reference.Split(optionValue.ProjectReferenceTypeSeparator);
                if(refs.Length != 2)
                    continue;

                projectTaskReferenceList
                    .Add(new ProjectTaskReference { ReferenceType = refs[0], Reference = refs[1] });
            }

            projectTaskReferences = projectTaskReferenceList.ToArray();

            return projectTaskReferenceList.Count > 0;
        }

        public ProjectTaskReferenceService(IOptions<ProjectTaskReferenceOptions> options, 
            IRepository<ProjectTaskReference> projectTaskReferenceRepository)
        {
            _options = options;
            _projectTaskReferenceRepository = projectTaskReferenceRepository;
        }
    }
}
