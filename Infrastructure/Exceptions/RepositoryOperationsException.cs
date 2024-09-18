using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions;
public class RepositoryOperationsException : Exception
{
    public string EntityName { get; }
    public RepositoryOperationsException(string message, string entityName, Exception innerException = null)
        : base(message, innerException)
    {
        EntityName = entityName;
    }
}

public class CreateException : RepositoryOperationsException
{
    public CreateException(string message, string entityName, Exception innerException = null)
        : base(message, entityName, innerException)
    {
    }
}

public class RetrieveException : RepositoryOperationsException
{
    public RetrieveException(string message, string entityName, Exception innerException = null)
        : base(message, entityName, innerException)
    {
    }
}

public class UpdateException : RepositoryOperationsException
{
    public UpdateException(string message, string entityName, Exception innerException = null)
        : base(message, entityName, innerException)
    {
    }
}

public class DeleteException : RepositoryOperationsException
{
    public DeleteException(string message, string entityName, Exception innerException = null)
        : base(message, entityName, innerException)
    {
    }
}