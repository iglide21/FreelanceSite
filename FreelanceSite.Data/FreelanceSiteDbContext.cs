namespace FreelanceSite.Data
{
    using FreelanceSite.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FreelanceSiteDbContext : IdentityDbContext<User>
    {
        public FreelanceSiteDbContext(DbContextOptions<FreelanceSiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectsCategories> ProjectsCategories { get; set; }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ProjectsCategories>()
                .HasKey(pc => new { pc.ProjectId, pc.CategoryId });

            builder
                .Entity<Budget>()
                .HasMany(b => b.Projects)
                .WithOne(p => p.Budget)
                .HasForeignKey(b => b.BudgetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<ProjectsCategories>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .Entity<ProjectsCategories>()
               .HasOne(c => c.Project)
               .WithMany(p => p.Categories)
               .HasForeignKey(c => c.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Project>()
                .HasMany(p => p.Bids)
                .WithOne(b => b.Project)
                .HasForeignKey(b => b.ProjectId);

            builder
                .Entity<User>()
                .HasMany(u => u.Bids)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            base.OnModelCreating(builder);
        }

    }
}
