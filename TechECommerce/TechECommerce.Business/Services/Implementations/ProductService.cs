using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TechECommerce.Business.Services.Interfaces;
using TechECommerce.Business.Utilities.DTOs.Common;
using TechECommerce.Business.Utilities.DTOs.Product;
using TechECommerce.Business.Utilities.Exceptions.ProductExceptions;
using TechECommerce.Core.Models;
using TechECommerce.DataAccess.Repositories.Interface;

namespace TechECommerce.Business.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductGetResponseDto>> GetAllProductsAsyncs(string? search)
    {
        var products =await _productRepository.GetFiltered(p => string.IsNullOrEmpty(search) ? true : p.Name.ToLower().Contains(search.Trim().ToLower())).ToListAsync();

        if (products is null || products.Count == 0)
            throw new ProductNotFoundException("No authors were found matching the provided criteria.");

        var productsDto = _mapper.Map<List<ProductGetResponseDto>>(products);
        return productsDto;
    }

    public async Task<ProductGetResponseDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
            throw new ProductNotFoundException($"Author with ID {id} not found.");

        var productDto = _mapper.Map<ProductGetResponseDto>(product);
        return productDto;
    }

    public async Task<ResponseDto> CreateProductAsync(ProductPostDto ProductPostDto)
    {
        bool isExist = await _productRepository.IsExistAsync(a => a.Name.ToLower().Trim() == ProductPostDto.Name.ToLower().Trim());
        if (isExist) throw new ProductAlreadyExistException("A product with the same name already exists.");

        var newProduct = _mapper.Map<Product>(ProductPostDto);

        await _productRepository.CreateAsync(newProduct);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.Created, "Product has been successfully created");
    }

    public async Task<ResponseDto> UpdateProductAsync(ProductPutDto ProductPutDto)
    {
        bool isExist = await _productRepository.IsExistAsync(p => p.Name.ToLower().Trim() == ProductPutDto.Name.ToLower().Trim() && p.Id != ProductPutDto.Id);
        if (isExist) throw new ProductAlreadyExistException($"An Product with the name '{ProductPutDto.Name}' already exists.");

        var product = await _productRepository.GetSingleAsync(b => b.Id == ProductPutDto.Id);
        if (product is null) throw new ProductNotFoundException($"Product not found with ID {ProductPutDto.Id}");


        var updatedProduct = _mapper.Map(ProductPutDto, product);

        _productRepository.Update(updatedProduct);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.OK, "Product has been successfully updated");
    }

    public async Task<ResponseDto> DeleteProductAsync(int Id)
    {
        var book = await _productRepository.GetSingleAsync(p => p.Id == Id);
        if (book is null)
            throw new ProductNotFoundException($"The book with ID {Id} was not found");

        _productRepository.SoftDelete(book);
        await _productRepository.SaveAsync();

        return new((int)HttpStatusCode.OK, "The book has been successfully deleted");
    } 
}
