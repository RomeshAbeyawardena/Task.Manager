using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMan.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public Task<ActionResult> Index()
        {
            return Task.FromResult<ActionResult>(View());
        }
    }
}
