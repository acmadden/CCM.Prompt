using Application.Models;
using ECommerceApplication.Data;

namespace Appliction.Services;

internal sealed class SaleService : ISaleService
{
    public IEnumerable<ProductTrendAnalysis> GetProductTrendAnalysis()
    {
        var sales = new Dictionary<string, bool>();

        foreach (var sale in Db.MonthlySales)
        {
            // Begin tracking the product if it hasn't already started.
            if (!sales.ContainsKey(sale.ProductName))
            {
                sales[sale.ProductName] = sale.QuantitySold > 50;
            }
            // If it's been consistently a high seller, then check this month to continue the trend
            else if (sales[sale.ProductName])
            {
                sales[sale.ProductName] = sale.QuantitySold > 50;
            }
        }

        return sales.Select(sale => new ProductTrendAnalysis { Name = sale.Key, ConsistentHighSales = sale.Value });
    }
}