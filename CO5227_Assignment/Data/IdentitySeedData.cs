
using Microsoft.AspNetCore.Identity;


namespace CO5227_Assignment.Data
{
    public class IdentitySeedData
    {

        public static async Task Initialise(CO5227_AssignmentContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminRole = "Admin";
            string memberRole  = "Member";
            string globalPassword = "P@55word"; //not ideal

            //create admin role if doesnt exist
            if(await roleManager.FindByNameAsync(adminRole) == null) 
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            //create member role if doesnt exist
            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }

            //if admin user doesnt exist, create one
            if(await userManager.FindByNameAsync("admin@oishiisushi.co.uk") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@oishiisushi.co.uk",
                    Email = "admin@oishiisushi.co.uk",
                    PhoneNumber = "07123456789"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, globalPassword);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            //if member user doesnt exist, create one
            if(await userManager.FindByNameAsync("member@oishiisushi.co.uk") == null)
            {
                
                var user = new IdentityUser
                {
                    UserName = "member@oishiisushi.co.uk",
                    Email = "member@oishiisushi.co.uk",
                    PhoneNumber = "07123456789"
                   
                };

                var result = await userManager.CreateAsync (user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync (user, globalPassword);
                    await userManager.AddToRoleAsync (user, memberRole);
                }
            }

        }

        
    }
}
