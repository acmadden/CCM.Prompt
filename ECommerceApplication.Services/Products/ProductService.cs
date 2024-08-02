using System.Text.Json;
using Application.Models;
using ECommerceApplication.Data;

namespace Appliction.Services;

internal sealed class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(int limit)
    {
        var response = await _httpClient.GetAsync($"/products?limit={limit}");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<Product>();
        }
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var deserialized = JsonSerializer.Deserialize<IEnumerable<Product>>(
            await response.Content.ReadAsStreamAsync(), options
        );
        return deserialized ?? Enumerable.Empty<Product>();
    }

    public IEnumerable<ProductPair> GetProductPairs(int topN)
    {
        var pairs = new Dictionary<string, int>();

        foreach (var order in Db.Orders)
        {
            // Generate the product key i.e. "Running Shoes_Socks"
            var keys = order.Products.SelectMany((product, i) =>
                order.Products
                    .Skip(i + 1)
                    .Select(next => string.Join("_", new List<string> { product.ProductName, next.ProductName }.Order()))
            );

            foreach (var key in keys)
            {
                // Begin tracking the pair if it hasn't already started.
                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, 1);
                }
                // Increment the frequency if another paired instance occurs.
                else
                {
                    pairs[key] = pairs[key] + 1;
                }
            }
        }

        // Map the dictionary to the expected response
        return pairs
            .Select(pair => new ProductPair { Products = pair.Key.Split("_"), Frequency = pair.Value })
            .OrderByDescending(pair => pair.Frequency)
            .Take(topN);
    }

    public IEnumerable<UniqueProduct> GetUniqueProducts(int year)
    {
        return Db.Orders
            .Where(order => order.PurchaseTime.Year == year)
            .SelectMany(order => order.Products)
            .DistinctBy(product => product.ProductId)
            .Select(product => new UniqueProduct { ProductId = product.ProductId, ProductName = product.ProductName, Category = product.Category });
    }
}