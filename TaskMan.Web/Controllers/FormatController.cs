using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Web.Controllers
{
    public class FormatController : ControllerBase
    {
        public FormatController(IMediator mediator, IMapper mapper) 
            : base(mediator, mapper)
        {
        }
    }
}
