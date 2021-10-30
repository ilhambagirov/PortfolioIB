using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Core.Infrastructor;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.BlogModules.BlogUser
{
    public class BlogComments : IRequest<CommandJsonResponse>
    {
        public int postId { get; set; }
        public int? userId { get; set; }
        public string comment { get; set; }
        public class BlogCommentsHandler : IRequestHandler<BlogComments, CommandJsonResponse>
        {
            readonly PortfolioDbContext db;
            public BlogCommentsHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(BlogComments request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();
                if (string.IsNullOrWhiteSpace(request.comment))
                {
                    response.Error = true;
                    response.Message = "Fill the area!";
                }
                if (request.postId < 1)
                {
                    response.Error = true;
                    response.Message = "Blog is not current!";
                }
                var post = await db.Blogs.FirstOrDefaultAsync(b => b.Id == request.postId);
                if (post == null)
                {
                    response.Error = true;
                    response.Message = "Blog is not current!";
                }

                if (request.userId.HasValue && await db.BlogComments.AnyAsync(u => u.Id == request.userId))
                {
                    db.BlogComments.Add(new BlogComment
                    {
                        ParentId = request.userId,
                        BlogId = request.postId,
                        Comment = request.comment,
                        //CreatedByUserId = User.GetUserId()
                    }); ;
                }




                return response;
            }
        }

    }
}
