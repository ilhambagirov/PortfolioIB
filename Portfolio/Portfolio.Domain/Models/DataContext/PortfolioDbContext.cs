using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models.Entities;

namespace Portfolio.Domain.Models.DataContext
{
    public class PortfolioDbContext : DbContext
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

    }
}
