using MediatR;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using Portfolio.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.BlogModules.BlogUser
{
    public class BlogPagedQuery : IRequest<PagedViewModel<Blog>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;

        public class BlogPagedViewHandler : IRequestHandler<BlogPagedQuery, PagedViewModel<Blog>>
        {
            readonly PortfolioDbContext db;
            public BlogPagedViewHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Blog>> Handle(BlogPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Blogs.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .AsQueryable();
                return new PagedViewModel<Blog>(query, request.PageIndex, request.PageSize);
            }
        }
    }
}
