using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;
using OLSoftware.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Infrastructure.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        private readonly OlsoftwareContext context;
        private readonly string _connectionString;

        public ProjectRepository(OlsoftwareContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        public async Task<IEnumerable<Project>> GetProjectWithClient()
        {

            var result = await context.Project.Include(b => b.UserProjects).ToListAsync();

            return result;
        }

        
    }
}
