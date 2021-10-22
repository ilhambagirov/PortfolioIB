using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.Entities;
using Portfolio.Domain.Models.Entities.Membership;

namespace Portfolio.Domain.Models.DataContext
{
    public class PortfolioDbContext : IdentityDbContext<PortfolioUser, PortfolioRole,int, PortfolioUserClaim, PortfolioUserRole, PortfolioUserLogin , PortfolioRoleClaim, PortfolioUserToken>
    {

        public PortfolioDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Experience> Experiences { get; set; } 
        public DbSet<Education> Educationss { get; set; }
        public DbSet<Bio> Bio { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PortfolioUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });

            builder.Entity<PortfolioRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });

            builder.Entity<PortfolioUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });

            builder.Entity<PortfolioUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });

            builder.Entity<PortfolioUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });

            builder.Entity<PortfolioRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });

            builder.Entity<PortfolioUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });


        }

    }
}
