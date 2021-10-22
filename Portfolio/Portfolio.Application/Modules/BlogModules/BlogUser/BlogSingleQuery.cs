using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.BlogModules.BlogUser
{

    public class BlogSingleQuery : IRequest<Blog>
    {
        public int Id { get; set; }

        public class BlogSingleQueryHandler : IRequestHandler<BlogSingleQuery, Blog>
        {
            readonly PortfolioDbContext db;
            public BlogSingleQueryHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<Blog> Handle(BlogSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id <= 0)
                {
                    return null;
                }

                var project = await db.Blogs
                    .Include(b=>b.CreatedByUser)
               .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return project;
            }
        }

    }
}
