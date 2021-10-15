using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
namespace Portfolio.Application.Modules.ProjectModules.ProjectUser
{
    public class ProjectSingleQuery : IRequest<Project>
    {

        public int Id { get; set; }

        public class ProjectSingleQueryHandler : IRequestHandler<ProjectSingleQuery, Project>
        {
            readonly PortfolioDbContext db;
            public ProjectSingleQueryHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<Project> Handle(ProjectSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id <= 0)
                {
                    return null;
                }

                var project = await db.Projects
               .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return project;
            }
        }

    }
}
