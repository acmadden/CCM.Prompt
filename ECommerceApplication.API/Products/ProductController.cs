using Application.Models;
using Appliction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.API;

[ApiController]
public sealed class ProductController : ControllerBase
{
    private readonly IProductService _products;

    public ProductController(IProductService products)
    {
        _products = products;
    }

    [HttpGet("/products/partner")]
    public async Task<IEnumerable<Product>> GetProductsAsync([FromQuery] int limit = 1)
    {
        return await _products.GetProductsAsync(limit);
    }

    [HttpGet("/products/top-pairs")]
    public IEnumerable<ProductPair> GetTopProductPairs([FromQuery] int topN = 1)
    {
        return _products.GetProductPairs(topN);
    }

    [HttpGet("/products/unique")]
    public IEnumerable<UniqueProduct> GetUniqueProducts([FromQuery] int year = 2024)
    {
        return _products.GetUniqueProducts(year);
    }
}