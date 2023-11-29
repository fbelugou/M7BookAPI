using Domain.Entities;

namespace DAL.Repositories.Interfaces;

public interface IGenericWriteRepository<T> where T : IEntity
{
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> DeleteAsync(T entity);
}