using Microsoft.EntityFrameworkCore;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Infrastructure.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        private readonly OlsoftwareContext context;




        public ProjectRepository(OlsoftwareContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectWithClient()
        {

            var result = await context.Project.Include(b => b.UserProjects).ToListAsync();

            return result;
        }

        

    }
}
