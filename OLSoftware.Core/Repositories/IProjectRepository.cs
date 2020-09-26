using OLSoftware.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OLSoftware.Core.Repositories.IRepositoryBase;

namespace OLSoftware.Core.Repositories
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        public Task<IEnumerable<Project>> GetProjectWithClient();

    }
}
