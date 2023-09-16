namespace ApiGestion.ApplicationCore.Common.Exceptions;
public class DuplicateIdentifierException : Exception
{
    public DuplicateIdentifierException()
        : base("Duplicate identifier")
    {
    }

    public DuplicateIdentifierException(string message)
        : base(message)
    {
    }

    public DuplicateIdentifierException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DuplicateIdentifierException(string name, object key)
        : base($"Entity \"{name}\" with identifier ({key}) already exists.")
    {
    }
}
