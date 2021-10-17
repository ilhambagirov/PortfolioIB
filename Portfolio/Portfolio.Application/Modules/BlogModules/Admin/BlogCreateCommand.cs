using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using Portfolio.Application.Core.Extension;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.BlogModules.Admin
{
    public class BlogCreateCommand : IRequest<int>
    {

        public string BlogName { get; set; }
        public string BlogType { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public IFormFile File { get; set; }
        public class BlogCreateCommandHandler : IRequestHandler<BlogCreateCommand, int>
        {

            readonly PortfolioDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public BlogCreateCommandHandler(PortfolioDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(BlogCreateCommand request, CancellationToken cancellationToken)
            {
                if (request.File == null)
                {
                    ctx.ActionContext.ModelState.AddModelError("file", "Not chosen");
                };

                if (ctx.IsModelStateValid())
                {
                    var blog = new Blog();
                    blog.BlogName = request.BlogName;
                    blog.Description = request.Description;
                    blog.BlogType = request.BlogType;
                    blog.ShortDescription = request.ShortDescription;
                    var extension = Path.GetExtension(request.File.FileName);
                    blog.ImagePath = $"{Guid.NewGuid()}{extension}";
                    var physicalAddress = Path.Combine(env.ContentRootPath,
                        "wwwroot",
                        "uploads",
                        "images",
                        blog.ImagePath);

                    using (var stream = new FileStream(physicalAddress, FileMode.Create, FileAccess.Write))
                    {
                        await request.File.CopyToAsync(stream);
                    }

                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);
                    return blog.Id;
                }
                return 0;

            }
        }
    }
}
