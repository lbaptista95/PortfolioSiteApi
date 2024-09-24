using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using PortfolioSiteApi.Models.Entity;

namespace PortfolioSiteApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobProposal> JobProposals { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaProject> MediaProject { get; set; }
        public DbSet<Skill> Skills {get; set;}
        public DbSet<SkillProject> SkillProject {get; set;}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().ToTable("projects");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<JobProposal>().ToTable("job_proposals");
            modelBuilder.Entity<Media>().ToTable("media");
            modelBuilder.Entity<MediaProject>().ToTable("media_project");
            modelBuilder.Entity<Skill>().ToTable("skills");
            modelBuilder.Entity<SkillProject>().ToTable("skill_project");

            modelBuilder.Entity<MediaProject>()
            .HasKey(mp => new { mp.ProjectId, mp.MediaId });

            modelBuilder.Entity<MediaProject>().
            HasOne(mp => mp.Project).WithMany(p => p.MediaProjects).HasForeignKey(mp => mp.ProjectId);
            
            modelBuilder.Entity<MediaProject>().
            HasOne(mp => mp.Media).WithOne(m => m.MediaProject).HasForeignKey<MediaProject>(mp=>mp.MediaId);

            modelBuilder.Entity<SkillProject>()
            .HasKey(mp => new { mp.ProjectId, mp.SkillId });

            modelBuilder.Entity<SkillProject>().
            HasOne(sp => sp.Project).WithMany(p => p.SkillProjects).HasForeignKey(mp => mp.ProjectId);
            
            modelBuilder.Entity<SkillProject>().
            HasOne(sp => sp.Skill).WithMany(m => m.SkillProjects).HasForeignKey(mp => mp.SkillId);

            modelBuilder.Entity<Project>().Property(p => p.Company).IsRequired(false);
            modelBuilder.Entity<Project>().Property(p => p.Client).IsRequired(false);
        }
    }
}
