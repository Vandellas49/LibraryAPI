using BL.InterFaces;
using DAL.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Specifications
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private IQueryable<T> EvaluateSpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
        private readonly LibraryDBContexts _dbContext;
        public GenericRepository(LibraryDBContexts dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await EvaluateSpecification(spec).CountAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(ISpecification<T> spec)
        {
            return await EvaluateSpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec)
        {
            return await EvaluateSpecification(spec).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            var local = _dbContext.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entry.Id));
            _dbContext.Entry(local).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {

                var entity = await _dbContext.Set<T>().FindAsync(id);
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
        }

        public async Task<bool> Any(ISpecification<T> spec)
        {
            return await EvaluateSpecification(spec).AnyAsync();
        }
    }
}
