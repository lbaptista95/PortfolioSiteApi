using Microsoft.EntityFrameworkCore;
using PortfolioSiteApi.Models;

namespace PortfolioSiteApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FieldProject> FieldsProjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobProposal> JobProposals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>().ToTable("fields");
            modelBuilder.Entity<Project>().ToTable("projects");
            modelBuilder.Entity<FieldProject>().ToTable("fields_projects");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<JobProposal>().ToTable("job_proposals");
        }
    }
}
