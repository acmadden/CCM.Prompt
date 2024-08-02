using Application.Models;

namespace Appliction.Services;

public interface ISaleService
{
    IEnumerable<ProductTrendAnalysis> GetProductTrendAnalysis();
}