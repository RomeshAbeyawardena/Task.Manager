using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Contracts.Services
{
    public interface ITaskReferenceService
    {
        bool TryGetReferences(string references, out IEnumerable<TaskReference> projectTaskReferences);
        Task<TaskReference> Save(TaskReference projectTaskReference, bool saveChanges, CancellationToken cancellationToken);
    }
}
