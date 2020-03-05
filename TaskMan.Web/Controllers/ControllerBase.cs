using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        public ControllerBase(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
    }
}
