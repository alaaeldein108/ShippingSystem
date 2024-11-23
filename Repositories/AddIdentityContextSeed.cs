using Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AddIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    Id = "00000001",
                    UserName = "AlaaEldein",
                    Email = "alaa@gmail.com",
                    DisplayName = "Alaa Eldein",
                    Status = Data.Entities.Enums.StatusEnum.Active
                };
                var role = new AppRole()
                {
                    Name = "Admin"
                };
                
                var userResult = await userManager.CreateAsync(user, "Aa@12345");

                var roleResult = await roleManager.CreateAsync(role);

                var userRole = await userManager.AddToRoleAsync(user, role.Name);


                if (userResult.Succeeded && roleResult.Succeeded)
                {
                    // Optionally, you can log that the user was created successfully.
                    Console.WriteLine("User created successfully.");
                }
                else
                {
                    // Log the errors
                    foreach (var error in userResult.Errors)
                    {
                        Console.WriteLine($"Error creating user: {error.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Users already exist, skipping seeding.");
            }
        }
    }

}
