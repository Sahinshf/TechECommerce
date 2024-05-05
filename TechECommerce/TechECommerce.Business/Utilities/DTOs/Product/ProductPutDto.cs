namespace TechECommerce.Business.Utilities.DTOs.Product;

public record ProductPutDto(int Id, string Name, string Description, string Color, string OperatingSystem, int Storage, decimal Price);