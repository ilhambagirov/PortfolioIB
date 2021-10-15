using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portfolio.Application.Core.Extension;
using Portfolio.Application.Core.Infrastructor;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Modules.ContactModules.ContactUser
{
    public class ContactCreateCommand : IRequest<CommandJsonResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public class ContactCreateCommandHandler : IRequestHandler<ContactCreateCommand, CommandJsonResponse>
        {
            readonly PortfolioDbContext db;
            readonly IActionContextAccessor ctx;
            public ContactCreateCommandHandler(PortfolioDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<CommandJsonResponse> Handle(ContactCreateCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();
                if (ctx.IsModelStateValid())
                {
                    var contact = new Contact();
                    contact.Name = request.Name;
                    contact.Email = request.Email;
                    contact.Subject = request.Subject;
                    contact.Content = request.Content;
                    db.Contacts.Add(contact);
                    await db.SaveChangesAsync(cancellationToken);
                    response.Error = false;
                    response.Message = "Successfully";
                    return response;
                }
                response.Error = true;
                response.Message = "Error,Try again";
                return response;
            }
        }

    }
}
