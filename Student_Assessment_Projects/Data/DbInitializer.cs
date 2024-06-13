using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Student_Assessment_Projects.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Create roles
            string[] roleNames = { "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a teacher user
            var teacher = new IdentityUser { UserName = "teacher@example.com", Email = "teacher@example.com" };
            var result = await userManager.CreateAsync(teacher, "Password123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(teacher, "Teacher");
            }
        }
    }
}
