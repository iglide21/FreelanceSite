using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Web.Extensions
{
    using FreelanceSite.Data;
    using FreelanceSite.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FreelanceSite.Web.ViewModels.AccountViewModels;
    using static GlobalConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<FreelanceSiteDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var roles = new List<string>()
                    {
                        AdministratorRole,
                        ModeratorRole,
                        FreelancerRole
                    };

                    var adminName = AdministratorRole;

                    foreach (var role in roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role,
                            });
                        }
                    }

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = "admin@admin.com",
                            UserName = "Admin",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Role = "Administrator"
                        };

                        await userManager.CreateAsync(adminUser, "asdasd");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                    .Wait();
            }

            return app;
        }

        public static IApplicationBuilder SeedBudgetsAndCategories(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<FreelanceSiteDbContext>();

                if (!db.Budgets.Any())
                {
                    var lower = 50;
                    var higher = 100;

                    for (int i = 0; i < 30; i++)
                    {
                        Budget budget = new Budget()
                        {
                            LowerBound = lower,
                            HigherBound = higher
                        };

                        lower += 50;
                        higher += 50;
                        db.Budgets.Add(budget);
                        db.SaveChanges();
                    }
                }

                if (!db.Categories.Any())
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Category cat = new Category
                        {
                            Title = $"Category{i}"
                        };
                        db.Categories.Add(cat);
                        db.SaveChanges();
                    }
                }
            }

            return app;
        }
    }
}
