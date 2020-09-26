using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OLSoftware.Core.Entities;

namespace OLSoftware.Infrastructure.Data
{
    public class OlsoftwareContext : DbContext
    {
        public OlsoftwareContext(DbContextOptions<OlsoftwareContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }
        public DbSet<ProjectLanguage> ProjectLanguage { get; set; }



    }
}
