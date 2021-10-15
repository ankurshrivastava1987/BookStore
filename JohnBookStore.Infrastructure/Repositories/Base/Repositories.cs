using JohnBookStore.Infrastructure.IRepositories.Base;
using JohnBookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JohnBookStore.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly JohnBookStoreContext _johnBookStoreContext;

        public Repository(JohnBookStoreContext johnBookStoreContext)
        {
            _johnBookStoreContext = johnBookStoreContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _johnBookStoreContext.Set<T>().AddAsync(entity);
            await _johnBookStoreContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _johnBookStoreContext.Set<T>().Remove(entity);
            await _johnBookStoreContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _johnBookStoreContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _johnBookStoreContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
