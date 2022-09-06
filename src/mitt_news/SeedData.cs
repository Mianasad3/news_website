using Microsoft.AspNetCore.Identity;

namespace mitt_news
{
    public class SeedData
    {
        private static UserManager<IdentityUser> UserManager { get; set; }
        private static RoleManager<IdentityRole> RoleManager { get; set; }

        public static async Task InsertNewData(IServiceProvider? serviceProvider)
        {
            UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            string roleName1 = "Administrator";

            IdentityRole role1 = await RoleManager.FindByNameAsync(roleName1);

            if (role1 == null)
            {
                role1 = new IdentityRole(roleName1);

                IdentityResult createRole1 = await RoleManager.CreateAsync(role1);

                if (createRole1.Succeeded)
                {
                    Console.WriteLine("Created role Administrator.");
                }
                else
                {
                    Console.WriteLine("Could not create role Administrator.");
                }
            }

            string roleName2 = "Editor";

            IdentityRole role2 = await RoleManager.FindByNameAsync(roleName2);

            if (role2 == null)
            {
                role2 = new IdentityRole(roleName2);

                IdentityResult createRole2 = await RoleManager.CreateAsync(role2);

                if (createRole2.Succeeded)
                {
                    Console.WriteLine("Editor Role has been Created.");
                }
                else
                {
                    Console.WriteLine("Fatal!! Failed to create a Role for Editor.");
                }
            }

            string userName1 = "johnsnow";

            IdentityUser user1 = await UserManager.FindByNameAsync(userName1);

            if (user1 == null)
            {
                user1 = new IdentityUser(userName1);

                IdentityResult saveUser1 = await UserManager.CreateAsync(user1, "Pass123$");

                if (saveUser1.Succeeded)
                {
                    Console.WriteLine($"User {userName1} saved to database.");
                }
                else
                {
                    Console.WriteLine($"Could not save user {userName1}");
                }
            }

            string userName2 = "peterbarlish";

            IdentityUser user2 = await UserManager.FindByNameAsync(userName2);

            if (user2 == null)
            {
                user2 = new IdentityUser(userName2);

                IdentityResult saveUser2 = await UserManager.CreateAsync(user2, "Pass321$");

                if (saveUser2.Succeeded)
                {
                    Console.WriteLine($"User {userName2} saved to database.");
                }
                else
                {
                    Console.WriteLine($"Could not save user {userName2}.");
                }
            }
        }
    }
}
