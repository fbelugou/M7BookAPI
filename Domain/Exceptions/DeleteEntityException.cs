
using Domain.Entities;

namespace Domain.Exceptions;

public class DeleteEntityException : Exception
{
    public DeleteEntityException(IEntity entity, int id) : base($"La suppression de {nameof(entity)} avec id : {id} dans la base de données a échoué") { }
}
