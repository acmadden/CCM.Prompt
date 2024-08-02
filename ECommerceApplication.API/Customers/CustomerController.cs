using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.API;

public sealed class CustomerController : ControllerBase
{
    private readonly ICustomerService _customers;

    public CustomerController(ICustomerService customers)
    {
        _customers = customers;
    }

    [HttpGet("customers/segment")]
    public IEnumerable<Customer> GetCustomers()
    {
        return _customers.GetCustomers();
    }
}