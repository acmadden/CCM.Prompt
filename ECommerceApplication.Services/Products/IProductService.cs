using Application.Models;

namespace Appliction.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync(int limit);
    IEnumerable<ProductPair> GetProductPairs(int topN);
    IEnumerable<UniqueProduct> GetUniqueProducts(int year);
}