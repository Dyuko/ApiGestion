namespace ApiGestion.ApplicationCore.Common.Exceptions;
public class BusinessException : Exception
{
    public BusinessException()
        : base("A business exception occurred")
    {
    }

    public BusinessException(string message)
        : base(message)
    {
    }

    public BusinessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}