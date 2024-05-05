using AutoMapper;
using TechECommerce.Business.Utilities.DTOs.Product;
using TechECommerce.Core.Models;

namespace TechECommerce.Business.Utilities.Mapper;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductGetResponseDto>().ReverseMap();
        CreateMap<ProductPostDto, Product>();
        CreateMap<ProductPutDto, Product>();

    }
}
