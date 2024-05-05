using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechECommerce.Business.Services.Interfaces;
using TechECommerce.Business.Utilities.DTOs.Product;

namespace TechECommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        return Ok( await _productService.GetAllProductsAsyncs(search));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        return Ok(await _productService.GetProductByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ProductPostDto productPostDto)
    {
        var response = await _productService.CreateProductAsync(productPostDto);

        return StatusCode(response.StatusCode, response.Message);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromForm] ProductPutDto productPutDto)
    {
        var response = await _productService.UpdateProductAsync(productPutDto);

        return StatusCode(response.StatusCode, response.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _productService.DeleteProductAsync(id);

        return StatusCode(response.StatusCode, response.Message);
    }
}
