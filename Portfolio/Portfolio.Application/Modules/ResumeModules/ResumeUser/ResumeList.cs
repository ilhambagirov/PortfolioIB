using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.ResumeModules.ResumeUser
{
    public class ResumeList : IRequest<ResumeViewModel>
    {
        public class ResumeListHandler : IRequestHandler<ResumeList, ResumeViewModel>
        {
            readonly PortfolioDbContext db;
            public ResumeListHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<ResumeViewModel> Handle(ResumeList request, CancellationToken cancellationToken)
            {
                var vm = new ResumeViewModel();

                vm.Experience = await db.Experiences.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .ToListAsync(cancellationToken);

                vm.Education = await db.Educationss.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .ToListAsync(cancellationToken);

                vm.Bio = await db.Bio.FirstOrDefaultAsync(b => b.DeleteByUserId == null && b.DeleteDate == null);

                vm.Skills = await db.Skills.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .ToListAsync(cancellationToken);

                return vm;

            }
        }
    }
}
