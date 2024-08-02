using Application.Models;

namespace Application.Services;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers();
}