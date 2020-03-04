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
using ResponseHelper = DNI.Shared.Domains.Response;

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

        [HttpPost, Route("project/task/save")]
        public async Task<ActionResult> SaveProjectTask(SaveProjectTaskViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = _mapper.Map<SaveProjectTaskViewModel, SaveProjectTaskRequest>(model);
            var response = await _mediator.Send(request);

            if(ResponseHelper.IsSuccessful(response))
                return Ok(response.Result);

            return BadRequest(response.Errors);
        }
    }
}
