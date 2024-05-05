using System.Net;

namespace TechECommerce.Business.Utilities.Exceptions.ProductExceptions;

public class ProductNotFoundException : Exception , IBaseException
{
    public ProductNotFoundException(string message) : base(message)
    {
        Message = message;        
    }
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; }
}
