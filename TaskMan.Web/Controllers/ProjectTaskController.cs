using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Domains.Requests;
using TaskMan.Domains.ViewModels;

namespace TaskMan.Web.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectTaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ActionResult> SaveProjectTask(SaveProjectTaskViewModel model)
        {
            var request = _mapper.Map<SaveProjectTaskViewModel, SaveProjectTaskRequest>(model);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
