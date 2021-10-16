using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.BlogModules.BlogUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class BlogsController : Controller
    {

        readonly IMediator mediator;
        public BlogsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }
        public async Task<IActionResult> Details(BlogSingleQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
