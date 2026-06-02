using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Interfaces
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
