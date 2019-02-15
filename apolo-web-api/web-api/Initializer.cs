using ApoloWebApi.Data;
using ApoloWebApi.Data.VO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApoloWebApi
{
    public static class Initializer
    {
        public static void SeedData(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPersonRepository repos)
        {
            SeedRoles(roleManager).Wait();
            SeedAdminUser(userManager, repos).Wait();
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var rolesNames = Enum.GetNames(typeof(Roles));
            
            foreach (var roleName in rolesNames)
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager, IPersonRepository repos)
        {
            var person = new Person { Name = "Admin" };
            var email = "admin@email.com";
            var password = "Admin@123";
            var user = new ApplicationUser { UserName = email, Email = email };

            if (await userManager.FindByEmailAsync(email) == null)
            {
                await userManager.CreateAsync(user, password);
                repos.AddPerson(user.Id, person);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
