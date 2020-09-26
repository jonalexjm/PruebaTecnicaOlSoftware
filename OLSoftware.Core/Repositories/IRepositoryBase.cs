using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Core.Repositories
{
    public interface IRepositoryBase
    {
        public interface IRepositoryBase<T> where T : class
        {
            Task<IEnumerable<T>> GetAll();
          

            Task<T> GetByIdAsync(int id);

            Task<T> CreateAsync(T entity);

            Task<T> UpdateAsync(T entity);

            Task DeleteAsync(T entity);

            Task<bool> ExistAsync(int id);
        }
    }
}
