using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.ProjectModules.ProjectUser;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        readonly IMediator mediator;
        public  ProjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ProjectPagedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Detail(ProjectSingleQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
