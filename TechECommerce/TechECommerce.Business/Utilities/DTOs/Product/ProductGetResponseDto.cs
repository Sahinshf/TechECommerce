namespace TechECommerce.Business.Utilities.DTOs.Product;

public record ProductGetResponseDto(int Id, string Name, string Description, string Color, string OperatingSystem, int Storage, decimal Price);