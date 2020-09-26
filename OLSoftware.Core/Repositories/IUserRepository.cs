using OLSoftware.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static OLSoftware.Core.Repositories.IRepositoryBase;

namespace OLSoftware.Core.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {

        public  Task<List<User>> GetAllSP();

        public Task<User> GetIdUser(int Id);

        public Task InsertUser(User user);

        public Task DeleteById(int Id);

        public Task UpdateUser(User user);

        public Task<List<User>> GetProjectWithClient();
    }
}
