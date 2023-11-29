using Domain.Entities;

namespace DAL.Repositories.Interfaces;
public interface IAuthorRepository : IGenericReadRepository<int, Author>, IGenericWriteRepository<Author>
{

}
