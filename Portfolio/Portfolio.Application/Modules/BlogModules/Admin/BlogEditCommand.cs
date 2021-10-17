using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Portfolio.Application.Core.Extension;
using Portfolio.Domain.Models.DataContext;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.BlogModules.Admin
{
    public class BlogEditCommand : BlogViewModel, IRequest<int>
    {
        public class BlogEditCommandHandler : IRequestHandler<BlogEditCommand, int>
        {
            readonly PortfolioDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public BlogEditCommandHandler(PortfolioDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(BlogEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }

                if (string.IsNullOrEmpty(request.fileTemp) && request.File == null)
                {
                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.Blogs.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.IsModelStateValid())
                {
                    entity.BlogName = request.BlogName;
                    entity.BlogType = request.BlogType;
                    entity.ShortDescription = request.ShortDescription;
                    entity.Description = request.Description;

                    if (request.File != null)
                    {
                        var extension = Path.GetExtension(request.File.FileName);
                        request.fileTemp = $"{Guid.NewGuid()}{extension}";
                        var physicalAddress = Path.Combine(env.ContentRootPath,
                            "wwwroot",
                            "uploads",
                            "images",
                             request.fileTemp);

                        using (var stream = new FileStream(physicalAddress, FileMode.Create, FileAccess.Write))
                        {
                            await request.File.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrEmpty(entity.ImagePath))
                        {
                            System.IO.File.Delete(Path.Combine(env.ContentRootPath,
                                                       "wwwroot",
                                                       "uploads",
                                                       "images",
                                                       entity.ImagePath));
                        }
                        entity.ImagePath = request.fileTemp;
                    }
                    await db.SaveChangesAsync(cancellationToken);
                    return entity.Id;

                }
                return 0;
            }
        }
    }
}
