using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace Portfolio.Application.Modules.ExperienceModules
{
    public class ExperienceSingleQuery : IRequest<Experience>
    {
        public int Id { get; set; }

        public class ExperienceSingleQueryHandler : IRequestHandler<ExperienceSingleQuery, Experience>
        {
            readonly PortfolioDbContext db;
            public ExperienceSingleQueryHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<Experience> Handle(ExperienceSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id <= 0)
                {
                    return null;
                }

                var experience = await db.Experiences
               .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return experience;
            }
        }

    }
}
