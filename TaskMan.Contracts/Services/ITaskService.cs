using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMan.Contracts.Services
{
    public interface ITaskService
    {
        Task<Domains.Data.Task> GetTask(string taskReference, CancellationToken cancellationToken);
        Task<Domains.Data.Task> Save(Domains.Data.Task task, bool saveChanges, CancellationToken cancellationToken);
        Task<Domains.Data.Task> GetTask(int taskId, CancellationToken cancellationToken);
    }
}
