namespace ApiGestion.ApplicationCore.Common.Exceptions;
public class NoContentException : Exception
{
    public NoContentException()
        : base("No entities found")
    {
    }

    public NoContentException(string message)
        : base(message)
    {
    }

    public NoContentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
