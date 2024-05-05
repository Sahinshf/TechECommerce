using TechECommerce.Business.Utilities.DTOs.Common;
using TechECommerce.Business.Utilities.DTOs.Product;

namespace TechECommerce.Business.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductGetResponseDto>> GetAllProductsAsyncs(string? search);
    Task<ProductGetResponseDto> GetProductByIdAsync(int id);
    Task<ResponseDto> CreateProductAsync(ProductPostDto ProductPostDto);
    Task<ResponseDto> UpdateProductAsync(ProductPutDto ProductPutDto);
    Task<ResponseDto> DeleteProductAsync(int Id);
}
