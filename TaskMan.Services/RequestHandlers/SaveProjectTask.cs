using DNI.Shared.Domains;
using FluentValidation.Results;
using MediatR;
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

namespace TaskMan.Services.RequestHandlers
{
    public class SaveProjectTask : IRequestHandler<SaveProjectTaskRequest, SaveProjectTaskResponse>
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly IProjectTaskService _projectTaskService;
        private readonly IProjectTaskStatusService _projectTaskStatusService;
        private readonly IProjectTaskCommentService _projectTaskCommentService;
        private readonly IProjectTaskReferenceService _projectTaskReferenceService;

        public SaveProjectTask(IProjectService projectService, ITaskService taskService, 
            IProjectTaskService projectTaskService, IProjectTaskStatusService projectTaskStatusService,
            IProjectTaskReferenceService projectTaskReferenceService,
            IProjectTaskCommentService projectTaskCommentService)
        {
            _projectService = projectService;
            _taskService = taskService;
            _projectTaskService = projectTaskService;
            _projectTaskStatusService =projectTaskStatusService;
            _projectTaskReferenceService = projectTaskReferenceService;
            _projectTaskCommentService = projectTaskCommentService;
        }

        public async Task<SaveProjectTaskResponse> Handle(SaveProjectTaskRequest request, CancellationToken cancellationToken)
        {
            var validationFailures = new List<ValidationFailure>();
            var isProjectIdDefault = request.ProjectId == default;
            var isStatusIdDefault = request.StatusId != default;
            var isTaskIdDefault = request.TaskId == default;
            var isCommentDefault = string.IsNullOrWhiteSpace(request.Comment);
            var isReferencesDefault = string.IsNullOrWhiteSpace(request.References);

            if(isProjectIdDefault && string.IsNullOrWhiteSpace(request.ProjectName))
                validationFailures.Add(new ValidationFailure(nameof(request.ProjectName), 
                    "Unable to create project with an empty project name"));

            if(isTaskIdDefault && string.IsNullOrWhiteSpace(request.TaskReference))
                validationFailures.Add(new ValidationFailure(nameof(request.TaskReference), 
                    "Unable to create task with an empty task reference"));

            if(validationFailures.Count > 0)
                return Response.Failed<SaveProjectTaskResponse>(validationFailures.ToArray());

            var project = (isProjectIdDefault) 
                ? await _projectService.Save(new Project { Name = request.ProjectName }, false, cancellationToken)
                : await _projectService.GetProject(request.ProjectId, cancellationToken);

            var task = (isTaskIdDefault)
                ? await _taskService.Save(new Domains.Data.Task { 
                    Reference = request.TaskReference, 
                    Description = request.TaskDescription }, false, cancellationToken)
                : await _taskService.GetTask(request.TaskId, cancellationToken);

            var projectTask = (isProjectIdDefault || isTaskIdDefault)
                ? await _projectTaskService.Save(new ProjectTask { Project = project, Task = task }, false)
                : await _projectTaskService.GetProjectTask(project.Id, task.Id);

            if(!isReferencesDefault && _projectTaskReferenceService.TryGetReferences(request.References, out var projectTaskReferences))
            {
                foreach(var projectTaskReference in projectTaskReferences)
                    await _projectTaskReferenceService.Save(projectTaskReference, false, cancellationToken);
            }

            if(!isStatusIdDefault)
            {
                ProjectTaskStatus currentStatus = await _projectTaskStatusService.GetCurrentStatus(projectTask.Id, cancellationToken);
                if(currentStatus.StatusId != request.StatusId)
                    await _projectTaskStatusService.Save(new ProjectTaskStatus { StatusId = request.StatusId, ProjectTask = projectTask },
                        false, cancellationToken);
            }

            if (!isCommentDefault)
            {
               var projectTaskComment = 
                    await _projectTaskCommentService.Save(new ProjectTaskComment { Value = request.Comment }, false, cancellationToken);
            }

            return Response.Success<SaveProjectTaskResponse>(projectTask);
        }
    }
}
