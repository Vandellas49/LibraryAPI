using BL.Specifications;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterFaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(ISpecification<T> spec);
        Task<bool> Any(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListBySpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
