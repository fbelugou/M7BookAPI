using Domain.Entities;

namespace Domain.Exceptions;

public class UpdateEntityException : Exception
{
    public UpdateEntityException(IEntity entity) : base($"La modification de {nameof(entity)} dans la base de données a échoué") { }
}
