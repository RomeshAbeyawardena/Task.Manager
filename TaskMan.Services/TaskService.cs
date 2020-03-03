using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Contracts.Services;

namespace TaskMan.Services
{
    public class TaskService : ITaskService
    {
        public Task<Domains.Data.Task> GetTask(string taskReference, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domains.Data.Task> GetTask(int taskId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domains.Data.Task> Save(Domains.Data.Task task, bool saveChanges, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
