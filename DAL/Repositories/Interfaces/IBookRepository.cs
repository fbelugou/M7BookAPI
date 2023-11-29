using Domain.Entities;

namespace DAL.Repositories.Interfaces;
public interface IBookRepository: IGenericReadRepository<int, Book>, IGenericWriteRepository<Book>
{
}
