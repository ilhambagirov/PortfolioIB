using MediatR;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using Portfolio.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.ExperienceModules
{
    public class ExperiencePagedQuery : IRequest<PagedViewModel<Experience>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public class ExperiencePagedQueryHandler : IRequestHandler<ExperiencePagedQuery, PagedViewModel<Experience>>
        {
            readonly PortfolioDbContext db;
            public ExperiencePagedQueryHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Experience>> Handle(ExperiencePagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Experiences.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .AsQueryable();

                /*   int recordCount = await query.CountAsync(cancellationToken);

                   var pagedData = await query.Skip((request.PageIndex - 1) * request.PageSize)
                     .Take(request.PageSize).ToListAsync(cancellationToken);*/

                return new PagedViewModel<Experience>(query, request.PageIndex, request.PageSize);
            }
        }
    }

}
