namespace FreelanceSite.Web
{
    using AutoMapper;
    using FreelanceSite.Data;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using FreelanceSite.Services;
    using FreelanceSite.Services.Implementations;
    using FreelanceSite.Web.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FreelanceSiteDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<FreelanceSiteDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IWorkService,WorkService>();
            services.AddTransient<IBudgetService,BudgetService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAdminUserService, AdminUserService>();


            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();
            app.SeedBudgetsAndCategories();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
