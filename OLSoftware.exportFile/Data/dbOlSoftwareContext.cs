using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OLSoftware.exportFile.Data
{
    public partial class dbOlSoftwareContext : DbContext
    {
        public dbOlSoftwareContext()
        {
        }

        public dbOlSoftwareContext(DbContextOptions<dbOlSoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectLanguage> ProjectLanguage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProject> UserProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= localhost\\SQLEXPRESS; Database=dbOlSoftware; Integrated security= true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectLanguage>(entity =>
            {
                entity.HasIndex(e => e.ProgrammingLanguageId);

                entity.HasIndex(e => e.ProjectId);

                entity.HasOne(d => d.ProgrammingLanguage)
                    .WithMany(p => p.ProjectLanguage)
                    .HasForeignKey(d => d.ProgrammingLanguageId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectLanguage)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasIndex(e => e.ProjectId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserProject)
                    .HasForeignKey(d => d.ProjectId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProject)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
