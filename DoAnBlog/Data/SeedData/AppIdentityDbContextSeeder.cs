
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

 namespace DataAccess.SeedData
{
    public class AppIdentityDbContextSeeder
    {
      
            public static async Task SeedAsync(IApplicationBuilder app)
            {

                using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ManageAppDbContext>();
                context.Database.EnsureCreated();

                var userManager =
                         serviceScope.ServiceProvider.GetService<UserManager<ManageUser>>();
                var roleManager =
                         serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                var ListRole = new List<string> { 
                
                "User",
                "BanUser"
                
                };
               
                    var defaultUser = new ManageUser { DisplayName = "vanSon", UserName = "SON", Email = "KientrucHaNoi@gmail.com" };
                    if ((await userManager.FindByNameAsync("SON")) == null)
                    {
                        await userManager.CreateAsync(defaultUser, "Pass@word1");
                        var roleName = "Admin";
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        await userManager.AddToRoleAsync(defaultUser, roleName);
                    }

                    var defaultUser1 = new ManageUser { DisplayName = "vanQuan", UserName = "QUAN", Email = "KientrucHaNoi@gmail.com" };
                    if ((await userManager.FindByNameAsync("QUAN")) == null)
                    {
                        await userManager.CreateAsync(defaultUser1, "Pass@word1");
                        var roleName = "Admin";
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        await userManager.AddToRoleAsync(defaultUser1, roleName);
                    }

                    var defaultUser2 = new ManageUser { DisplayName = "vanTuan", UserName = "TUAN", Email = "KientrucHaNoi@gmail.com" };
                    if ((await userManager.FindByNameAsync("TUAN")) == null)
                    {
                        await userManager.CreateAsync(defaultUser2, "Pass@word1");
                        var roleName = "Admin";
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        await userManager.AddToRoleAsync(defaultUser2, roleName);
                    }


                    var defaultUser3 = new ManageUser { DisplayName = "HoangCongQuang", UserName = "QUANG", Email = "KientrucHaNoi@gmail.com" };
                    if ((await userManager.FindByNameAsync("QUANG")) == null)
                    {
                        await userManager.CreateAsync(defaultUser3, "Pass@word1");
                        var roleName = "Admin";
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                        await userManager.AddToRoleAsync(defaultUser3, roleName);
                    }

                foreach (var item in ListRole)
                {
                    if ((await roleManager.FindByNameAsync(item)) == null)
                    {
                    
                        await roleManager.CreateAsync(new IdentityRole(item));
                     
                    }

                }



                await  context.SaveChangesAsync();
            }
            }

        
    }
}
