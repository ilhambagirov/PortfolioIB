using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.ContactModules.ContactUser;
using Portfolio.Domain.Models.Entities;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IMediator mediator;
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
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
