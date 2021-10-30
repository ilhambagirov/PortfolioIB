using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Core.Extension;
using Portfolio.Application.Modules.BlogModules.BlogUser;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class BlogsController : Controller
    {

        readonly IMediator mediator;
        readonly PortfolioDbContext db;
        public BlogsController(IMediator mediator, PortfolioDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(BlogSingleQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(int? userId, int postId, string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return Json(new
                {
                    Error = true,
                    Message = "Fill the area!"
                });
            }
            if (postId < 1)
            {
                return Json(new
                {
                    Error = true,
                    Message = "Blog is not current!"
                });
            }
            var post = await db.Blogs.FirstOrDefaultAsync(b => b.Id == postId);
            if (post == null)
            {
                return Json(new
                {
                    Error = true,
                    Message = "Blog is not current!"
                });
            }
            var commentModel = (new BlogComment
            {
                BlogId = postId,
                Comment = comment,
                CreatedByUserId = Convert.ToInt32(User.GetUserId())
            });

            if (userId.HasValue && await db.BlogComments.AnyAsync(u => u.Id == userId))
                commentModel.ParentId = userId;

            db.BlogComments.Add(commentModel);
            await db.SaveChangesAsync();

            commentModel = await db.BlogComments
                .Include(c=>c.CreatedByUser)
                .Include(c=>c.Parent)
                .Include(c=>c.Children)
                .FirstOrDefaultAsync(c=>c.Id== commentModel.Id);

            return PartialView("_Comment",commentModel);
        }
    }
}
