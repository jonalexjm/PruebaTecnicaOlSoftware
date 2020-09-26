using Microsoft.EntityFrameworkCore;
using OLSoftware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OLSoftware.Core.Interfaces;
using static OLSoftware.Core.Repositories.IRepositoryBase;

namespace OLSoftware.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        private readonly OlsoftwareContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryBase(OlsoftwareContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

        //public IQueryable<T> GetAll()
        //{
        //    return this.context.Set<T>().AsNoTracking();
        //}

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
