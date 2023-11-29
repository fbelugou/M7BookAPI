using Domain.Entities;

namespace DAL.Repositories.Interfaces;
public interface IGenericReadRepository<U, T> where T : IEntity
{
    public Task<T> GetByIdAsync(U id);
    public Task<IEnumerable<T>> GetAllAsync();

}
