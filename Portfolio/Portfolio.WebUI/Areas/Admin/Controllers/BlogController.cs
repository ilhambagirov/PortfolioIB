using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.BlogModules.Admin;
using Portfolio.Application.Modules.BlogModules.BlogUser;
using Riode.Application.Modules.BlogModule.Admin;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        readonly IWebHostEnvironment env;
        readonly IMediator mediator;

        public BlogController( IWebHostEnvironment env, IMediator mediator)
        {
            this.env = env;
            this.mediator = mediator;
        }

        //[Authorize(Policy = "admin.blogs.index")]
        public async Task<IActionResult> Index(BlogPagedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        //[Authorize(Policy = "admin.blogs.details")]
        public async Task<IActionResult> Details(BlogSingleQuery query)
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
        public async Task<IActionResult> Create(BlogCreateCommand command)
        {
            var id = await mediator.Send(command);
            if (id > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        //[Authorize(Policy = "admin.blogs.edit")]
        public async Task<IActionResult> Edit(BlogSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }
            BlogViewModel vm = new();
            vm.Id = blog.Id;
            vm.BlogName = blog.BlogName;
            vm.BlogType = blog.BlogType;
            vm.Description = blog.Description;
            vm.ShortDescription = blog.ShortDescription;
            vm.fileTemp = blog.ImagePath;
            return View(vm);
        }

        // POST: Admin/Blogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Policy = "admin.blogs.edit")]
        public async Task<IActionResult> Edit([FromRoute] int id, BlogEditCommand command)
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
        public async Task<IActionResult> Delete(BlogDeleteCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
