using Application.Models;
using Appliction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.API;

[ApiController]
public sealed class SaleController : ControllerBase
{
    private readonly ISaleService _sales;

    public SaleController(ISaleService sales)
    {
        _sales = sales;
    }

    [HttpGet("/sales/analyze")]
    public ActionResult<ProductTrendAnalysis> GetProductSales()
    {
        return Ok(_sales.GetProductTrendAnalysis());
    }
}