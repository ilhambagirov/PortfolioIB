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

namespace Portfolio.Application.Modules.ProjectModules.Admin
{
    public class ExperienceCreateCommand : IRequest<int>
    {

        public string TimeInterval { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public IFormFile File { get; set; }
        public class ExperienceCreateCommandHandler : IRequestHandler<ExperienceCreateCommand, int>
        {

            readonly PortfolioDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public ExperienceCreateCommandHandler(PortfolioDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(ExperienceCreateCommand request, CancellationToken cancellationToken)
            {
                if (request.File == null)
                {
                    ctx.ActionContext.ModelState.AddModelError("file", "Not chosen");
                };

                if (ctx.IsModelStateValid())
                {
                    var experience = new Experience();
                    experience.TimeInterval = request.TimeInterval;
                    experience.Occupation = request.Occupation;
                    experience.Location = request.Location;
                    experience.Description = request.Description;
                    experience.CompanyName = request.CompanyName;

                    var extension = Path.GetExtension(request.File.FileName);
                    experience.Logo = $"{Guid.NewGuid()}{extension}";
                    var physicalAddress = Path.Combine(env.ContentRootPath,
                        "wwwroot",
                        "uploads",
                        "images",
                        experience.Logo);

                    using (var stream = new FileStream(physicalAddress, FileMode.Create, FileAccess.Write))
                    {
                        await request.File.CopyToAsync(stream);
                    }

                    db.Add(experience);
                    await db.SaveChangesAsync(cancellationToken);
                    return experience.Id;
                }
                return 0;

            }
        }
    }
}
