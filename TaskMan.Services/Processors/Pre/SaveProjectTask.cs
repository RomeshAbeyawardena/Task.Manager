using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskMan.Domains.Requests;
using TaskMan.Domains.Responses;
using TaskMan.Domains.Data;
using TaskMan.Contracts.Services;
using TaskMan.Contracts.Providers;

namespace TaskMan.Services.Processors.Pre
{
    public class SaveProjectTask : IRequestPreProcessor<SaveProjectTaskRequest>
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IStatusService _statusService;
        private readonly ITaskManCacheProvider _taskManCacheProvider;

        public SaveProjectTask(ITaskService taskService, 
            IProjectService projectService, IStatusService statusService, 
            ITaskManCacheProvider taskManCacheProvider)
        {
            _taskService = taskService;
            _projectService = projectService;
            _statusService = statusService;
            _taskManCacheProvider = taskManCacheProvider;
        }

        public async System.Threading.Tasks.Task Process(SaveProjectTaskRequest request, CancellationToken cancellationToken)
        {
            Project foundProject;
            Domains.Data.Task foundTask;
            Status foundStatus;
            
            if(request.TaskId == default
                   && (foundTask = await _taskService.GetTask(request.TaskReference, cancellationToken)) != null)
                request.TaskId = foundTask.Id;
            
            if(request.ProjectId == default
                && (foundProject = await _projectService.GetProject(request.ProjectName, cancellationToken)) != null)
                request.ProjectId = foundProject.Id;

            var statuses = _taskManCacheProvider.GetStatuses(cancellationToken);

            if (request.StatusId == default
                && (foundStatus = _statusService.GetStatus(await statuses, request.Status)) != null)
                request.StatusId = foundStatus.Id;
        }
    }
}
