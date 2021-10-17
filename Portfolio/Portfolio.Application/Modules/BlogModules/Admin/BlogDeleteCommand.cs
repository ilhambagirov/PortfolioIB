using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Core.Infrastructor;
using Portfolio.Domain.Models.DataContext;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Application.Modules.BlogModule.Admin
{
    public class BlogDeleteCommand : IRequest<CommandJsonResponse>
    {
        public int? Id { get; set; }
        public class BlogDeleteCommandHandler : IRequestHandler<BlogDeleteCommand, CommandJsonResponse>
        {
            readonly PortfolioDbContext db;
            public BlogDeleteCommandHandler(PortfolioDbContext db)
            {
                this.db = db;
            }

            public async Task<CommandJsonResponse> Handle(BlogDeleteCommand request, CancellationToken cancellationToken)
            {

                var response = new CommandJsonResponse();
                if (request.Id == null || request.Id < 0)
                {
                    response.Error = true;
                    response.Message = "Item is not defined";
                    goto end;
                }

                var entity = await db.Blogs.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteByUserId == null);

                if (entity == null)
                {
                    response.Error = true;
                    response.Message = "Item is not found";
                    goto end;
                }

                entity.DeleteByUserId = 1;
                entity.DeleteDate = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);
                response.Error = false;
                response.Message = "Item is deleted";
            end:
                return response;
            }
        }
    }
}
