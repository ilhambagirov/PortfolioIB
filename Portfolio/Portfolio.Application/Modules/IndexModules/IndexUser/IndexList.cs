using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.IndexModules.IndexUser
{
    public class IndexList : IRequest<IndexViewModel>
    {
        public class ResumeListHandler : IRequestHandler<IndexList, IndexViewModel>
        {
            readonly PortfolioDbContext db;
            public ResumeListHandler(PortfolioDbContext db)
            {
                this.db = db;
            }
            public async Task<IndexViewModel> Handle(IndexList request, CancellationToken cancellationToken)
            {
                var vm = new IndexViewModel();

                vm.Skills = await db.Skills.Where(b => b.DeleteByUserId == null && b.DeleteDate == null)
                     .ToListAsync(cancellationToken);
                vm.Services = await db.Services.Where(b => b.DeleteByUserId == null && b.DeleteDate == null).Include(i => i.Icons)
                     .ToListAsync(cancellationToken);
                vm.PersonalDetails = await db.PersonalDetails.FirstOrDefaultAsync(b => b.DeleteByUserId == null && b.DeleteDate == null);
                return vm;
            }
        }
    }
}
