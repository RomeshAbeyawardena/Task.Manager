using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading;
using TaskMan.Contracts;
using TaskMan.Services;
using TaskMan.Domains.Requests;
using TaskMan.Domains.Responses;
using TaskMan.Web.Controllers;
using System.Threading.Tasks;
using TaskMan.Domains.ViewModels;
using AutoMapper;

namespace TaskMan.UnitTests
{
    public class ProjectTests
    {
        private Mock<IMediator> mediator;
        private Mock<IMapper> mapper;
        private ProjectTaskController projectTaskController;
        [SetUp]
        public void Setup()
        {
            mediator = new Mock<IMediator>();
            mapper = new Mock<IMapper>();
            projectTaskController = new ProjectTaskController(mediator.Object, mapper.Object);
        }

        [Test]
        public async Task SaveProjectTask_when_successful_returns_Status200()
        {
            var model = new SaveProjectTaskViewModel();
            var request = new SaveProjectTaskRequest();
            var cancellationToken = CancellationToken.None;

            mapper.Setup(m => m.Map<SaveProjectTaskViewModel, SaveProjectTaskRequest>(model))
                .Returns(request).Verifiable();

            mediator.Setup(m => m.Send(request, cancellationToken))
                .Returns(Task.FromResult(new SaveProjectTaskResponse {
                    })).Verifiable();
            
            var result = await projectTaskController.SaveProjectTask(model);
            mapper.VerifyAll();
            mediator.VerifyAll();
        }
    }
}