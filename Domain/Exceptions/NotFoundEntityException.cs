using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;
public class NotFoundEntityException: Exception
{
    public NotFoundEntityException(string entityName, int id): base($"L'entité {entityName} avec l'id: {id} est introuvable")
    {
        
    }
}
