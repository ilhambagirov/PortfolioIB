using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Modules.IndexModules.IndexUser;
using System.Threading.Tasks;

namespace Portfolio.Application.Core.Components
{
    public class PersonelDetailsViewComponent : ViewComponent
    {
        readonly IMediator mediator;
        readonly IndexList query;
        public PersonelDetailsViewComponent(IMediator mediator, IndexList query)
        {
            this.mediator = mediator;
            this.query = query;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
