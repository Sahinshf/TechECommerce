using System.Net;

namespace TechECommerce.Business.Utilities.Exceptions.ProductExceptions;

public class ProductAlreadyExistException : Exception, IBaseException
{
    public ProductAlreadyExistException(string message) : base(message)
    {
            Message = message;
    }
    public int StatusCode { get; set; } = (int)HttpStatusCode.Conflict;
    public string Message { get; set; }
}
