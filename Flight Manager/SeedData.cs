using FlightManager.Areas.Identity.Data;
using FlightManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var context = provider.GetRequiredService<FlightManagerDBContext>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = provider.GetRequiredService<UserManager<FlightManagerUser>>();

                context.Database.Migrate();
                AddRole(roleManager, "Administrator");
                AddRole(roleManager, "Worker");
                AssignAdminRole(userManager, "Administrator");
            }
        }

        public static void AssignAdminRole(UserManager<FlightManagerUser> userManager, string roleName)
        {
            FlightManagerUser admin = new FlightManagerUser
            {
                UserName = "Admin",
                Email = "admin@localhost.com"
            };

            IdentityResult result = userManager.CreateAsync(admin, "Admin1234!").Result;

            if (result.Succeeded)
            {
                    userManager.AddToRoleAsync(admin, roleName);
            }
        }

        public static void AddRole(RoleManager<IdentityRole> roleManager, string name)
        {
            var roleExist = roleManager.RoleExistsAsync(name).Result;
            if (!roleExist)
            {
                //create the roles and seed them to the database
                roleManager.CreateAsync(new IdentityRole(name)).GetAwaiter().GetResult();
            }
        }
    }
}
