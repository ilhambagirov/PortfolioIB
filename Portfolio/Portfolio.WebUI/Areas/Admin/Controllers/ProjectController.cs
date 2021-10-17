using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.ProjectModules.Admin;
using Portfolio.Application.Modules.ProjectModules.ProjectUser;
using Riode.Application.Modules.ProjectModules.Admin;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        readonly IWebHostEnvironment env;
        readonly IMediator mediator;

        public ProjectController(IWebHostEnvironment env, IMediator mediator)
        {
            this.env = env;
            this.mediator = mediator;
        }

        //[Authorize(Policy = "admin.blogs.index")]
        public async Task<IActionResult> Index(ProjectPagedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        //[Authorize(Policy = "admin.blogs.details")]
        public async Task<IActionResult> Details(ProjectSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        //[Authorize(Policy = "admin.blogs.create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.blogs.create")]
        public async Task<IActionResult> Create(ProjectCreateCommand command)
        {
            var id = await mediator.Send(command);
            if (id > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        //[Authorize(Policy = "admin.blogs.edit")]
        public async Task<IActionResult> Edit(ProjectSingleQuery query)
        {
            var project = await mediator.Send(query);
            if (project == null)
            {
                return NotFound();
            }
            ProjectViewModel vm = new();
            vm.Id = project.Id;
            vm.ProjectName = project.ProjectName;
            vm.ProjectType = project.ProjectType;
            vm.Description = project.Description;
            vm.Link = project.Link;
            vm.fileTemp = project.ImagePath;
            return View(vm);
        }

        // POST: Admin/Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Policy = "admin.blogs.edit")]
        public async Task<IActionResult> Edit([FromRoute] int id, ProjectEditCommand command)
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
        public async Task<IActionResult> Delete(ProjectDeleteCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
