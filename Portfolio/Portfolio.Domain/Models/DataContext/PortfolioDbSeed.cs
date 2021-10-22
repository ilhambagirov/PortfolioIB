﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models.DataContext
{
    public static class PortfolioDbSeed
    {
        static public IApplicationBuilder SeedMembership(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
                var hasroleAdminAndUser = db.Roles.Where(r => r.Name.Contains("SuperAdmin") ||
                r.Name.Contains("User")).Any();

                if (hasroleAdminAndUser == true)
                {
                    goto end;
                }

                var role = new PortfolioRole()
                {
                    Name = "SuperAdmin"
                };
                var userRole = new PortfolioRole()
                {
                    Name = "User"
                };



                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<PortfolioUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<PortfolioRole>>();



                var hasRole = roleManager.RoleExistsAsync(role.Name).Result;
                if (hasRole == true)
                {
                    var roleResult = roleManager.FindByNameAsync(role.Name).Result;
                }
                else
                {
                    var iResult = roleManager.CreateAsync(role).Result;
                    if (!iResult.Succeeded)
                    {
                        goto end;
                    }
                }

                var hasUserRole = roleManager.RoleExistsAsync(userRole.Name).Result;
                if (hasUserRole == true)
                {
                    var roleUserResult = roleManager.FindByNameAsync(userRole.Name).Result;
                }
                else
                {
                    var iUserResult = roleManager.CreateAsync(userRole).Result;
                    if (!iUserResult.Succeeded)
                    {
                        goto end;
                    }
                }

                var user = new PortfolioUser()
                {
                    UserName = "Ilham",
                    Email = "ilhambagirov027@gmail.com",
                    EmailConfirmed = true
                };

                var user2 = new PortfolioUser()
                {
                    UserName = "Tural",
                    Email = "turalbagirov027@gmail.com",
                    EmailConfirmed = true
                };
                var foundUser2 = userManager.FindByEmailAsync(user2.Email).Result;

                if (foundUser2 != null && !userManager.IsInRoleAsync(foundUser2, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser2, role.Name).Wait();
                }
                else if (foundUser2 == null)
                {
                    string password = "123";
                    var iUserResult = userManager.CreateAsync(user2, password).Result;
                    if (iUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user2, userRole.Name).Wait();
                    }
                }

                var foundUser = userManager.FindByEmailAsync(user.Email).Result;

                if (foundUser != null && !userManager.IsInRoleAsync(foundUser, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser, role.Name).Wait();
                }
                else if (foundUser == null)
                {
                    string password = "123";
                    var iUserResult = userManager.CreateAsync(user, password).Result;
                    if (iUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, role.Name).Wait();
                    }
                }

            }

        end:
            return app;
        }
    }
}
