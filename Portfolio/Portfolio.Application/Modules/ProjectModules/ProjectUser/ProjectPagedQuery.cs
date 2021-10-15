using MediatR;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using Portfolio.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.ProjectModules.ProjectUser
{
    public class ProjectPagedQuery : IRequest<PagedViewModel<Project>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;

        public class ProjectPagedQueryHandler : IRequestHandler<ProjectPagedQuery, PagedViewModel<Project>>
        {
            readonly PortfolioDbContext db;
            public ProjectPagedQueryHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Project>> Handle(ProjectPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Projects.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .AsQueryable();

                /*   int recordCount = await query.CountAsync(cancellationToken);

                   var pagedData = await query.Skip((request.PageIndex - 1) * request.PageSize)
                     .Take(request.PageSize).ToListAsync(cancellationToken);*/

                return new PagedViewModel<Project>(query, request.PageIndex, request.PageSize);
            }
        }
    }
}
