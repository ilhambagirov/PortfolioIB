using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Modules.ProjectModules.ProjectUser;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
               .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return project;
            }
        }

    }
}
