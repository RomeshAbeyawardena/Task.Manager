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

namespace TaskMan.Services.Processors.Pre
{
    public class SaveProjectTask : IRequestPreProcessor<SaveProjectTaskRequest>
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IStatusService _statusService;

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

            if(request.StatusId == default
                && (foundStatus = await _statusService.GetStatus(request.Status, cancellationToken)) != null)
                request.StatusId = foundStatus.Id;
        }
    }
}
