using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.ContactModules.ContactUser;
using Portfolio.Application.Modules.IndexModules.IndexUser;
using Portfolio.Application.Modules.ResumeModules.ResumeUser;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(IndexList query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Resume(ResumeList query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
