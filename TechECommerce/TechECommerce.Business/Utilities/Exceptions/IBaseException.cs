namespace TechECommerce.Business.Utilities.Exceptions;

public interface IBaseException
{
    int StatusCode { get; set; }
    string Message { get; set; }    
}
