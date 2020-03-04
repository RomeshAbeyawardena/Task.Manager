using DNI.Shared.Contracts;
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
        private readonly IRepository<Domains.Data.Task> _taskRepository;

        public async Task<Domains.Data.Task> GetTask(string taskReference, CancellationToken cancellationToken)
        {
            var query = _taskRepository.Query(task => task.Reference == taskReference);

            return await _taskRepository.For(query)
                .ToFirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Domains.Data.Task> GetTask(int taskId, CancellationToken cancellationToken)
        {
            return await _taskRepository.Find(false, cancellationToken, taskId);
        }

        public async Task<Domains.Data.Task> Save(Domains.Data.Task task, bool saveChanges, CancellationToken cancellationToken)
        {
            return await _taskRepository.SaveChanges(task, saveChanges, true, cancellationToken);
        }

        public TaskService(IRepository<Domains.Data.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
