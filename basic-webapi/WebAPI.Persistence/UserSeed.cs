using Microsoft.AspNetCore.Identity;
using WebAPI.Domain;

namespace WebAPI.Persistence;

public class UserSeed
{
    public static async Task Seed(MyDatabase database,
                                UserManager<AppUser> userManager,
                                RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            string ADMIN_ROLES_ID = "1d0ff279-13b1-4f6b-9aee-46322274fecd";
            string USER_ROLES_ID = "9a302bd4-1f46-45a8-a457-6aad1a88ea71";
            var rolesUser = new IdentityRole()
            {
                Id = USER_ROLES_ID,
                ConcurrencyStamp = USER_ROLES_ID,
                Name = "User",
                NormalizedName = "Reader".ToUpper()
            };
            var roleAdmin = new IdentityRole()
            {
                Id = ADMIN_ROLES_ID,
                ConcurrencyStamp = ADMIN_ROLES_ID,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            };
            await roleManager.CreateAsync(rolesUser);
            await roleManager.CreateAsync(roleAdmin);
        }

        if (!userManager.Users.Any())
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string USER_ID = "1c6caa06-2d27-44fd-8cc7-1c31d832bd99";
            var adminUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "bigpapa@gmail.com",
                EmailConfirmed = true,
                DisplayName = "Bob",
                UserName = "bigpapa@gmail.com",
                NormalizedUserName = "BIGPAPA@GMAIL.COM"
            };
            var userUser = new AppUser
            {
                Id = USER_ID,
                Email = "littlebro@gmail.com",
                EmailConfirmed = true,
                DisplayName = "Smith",
                UserName = "littlebro@gmail.com",
                NormalizedUserName = "LITTLEBRO@GMAIL.COM"
            };
            await userManager.CreateAsync(adminUser, "Pa$$word123");
            await userManager.CreateAsync(userUser, "123Pa$$word");
            await userManager.AddToRolesAsync(adminUser, ["Admin", "User"] );   //* new string[2] { "Admin", "User" }
            await userManager.AddToRoleAsync(userUser, "User");
        }

        if (!database.Categories.Any())
        {
            var Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = Guid.Parse("2aa57dad-f3ff-4fe4-ae64-95d50f7e1846"),
                    CategoryName = "Electronic",
                    Description = "This is electronics"
                },
                new Category()
                {
                    CategoryId = Guid.Parse("b3acd03a-7fe8-47fb-9103-5ab605c22836"),
                    CategoryName = "Fruit",
                    Description = "This is fruit"
                },
            };
            await database.AddRangeAsync(Categories);
            await database.SaveChangesAsync();
        }

        if (!database.Products.Any())
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.Parse("3e196f2b-b7f0-49e9-9644-c6c81935287b"),
                    ProductName = "TV",
                    Description = "This is television",
                    CategoryId = Guid.Parse("2aa57dad-f3ff-4fe4-ae64-95d50f7e1846")
                },
                new Product()
                {
                    ProductId = Guid.Parse("c660bce2-c410-482f-9a22-cd76c578fa21"),
                    ProductName = "HP",
                    Description = "This is handphone",
                    CategoryId = Guid.Parse("2aa57dad-f3ff-4fe4-ae64-95d50f7e1846")
                }
            };
            await database.Products.AddRangeAsync(products);
            await database.SaveChangesAsync();
        }
    }
}
