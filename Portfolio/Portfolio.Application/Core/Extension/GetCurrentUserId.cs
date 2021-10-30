using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Models.DataContext;
using System;
using System.Security.Claims;

namespace Portfolio.Application.Core.Extension
{
    public static partial class Extension
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }

}
