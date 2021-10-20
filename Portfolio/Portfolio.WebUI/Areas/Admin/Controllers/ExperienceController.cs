using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.ExperienceModules;
using Portfolio.Application.Modules.ProjectModules.Admin;
using Riode.Application.Modules.ProjectModules.Admin;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        readonly IWebHostEnvironment env;
        readonly IMediator mediator;

        public ExperienceController(IWebHostEnvironment env, IMediator mediator)
        {
            this.env = env;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(ExperiencePagedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Details(ExperienceSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.blogs.create")]
        public async Task<IActionResult> Create(ExperienceCreateCommand command)
        {
            var id = await mediator.Send(command);
            if (id > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Edit(ExperienceSingleQuery query)
        {
            var project = await mediator.Send(query);
            if (project == null)
            {
                return NotFound();
            }
            ExperienceViewModel vm = new();
            vm.Id = project.Id;
            vm.CompanyName = project.CompanyName;
            vm.Occupation = project.Occupation;
            vm.Location = project.Location;
            vm.TimeInterval = project.TimeInterval;
            vm.fileTemp = project.Logo;
            vm.Description = project.Description;
            return View(vm);
        }

        // POST: Admin/Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Policy = "admin.blogs.edit")]
        public async Task<IActionResult> Edit([FromRoute] int id, ExperienceEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            var _id = await mediator.Send(command);

            if (id > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }
        
        [HttpPost]
        //[Authorize(Policy = "admin.blogs.delete")]
        public async Task<IActionResult> Delete(ExperienceDeleteCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
