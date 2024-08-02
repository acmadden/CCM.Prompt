using Application.Models;
using ECommerceApplication.Data;

namespace Application.Services;

internal sealed class CustomerService : ICustomerService
{
    public IEnumerable<Customer> GetCustomers()
    {
        return Db.Purchases.GroupBy(purchase => purchase.CustomerId).Select(grouping =>
        {
            var purchaseAmount = grouping.Sum(purchase => purchase.Amount);
            var segment = "Bronze";
            if (purchaseAmount > 10000)
            {
                segment = "Gold";
            }
            else if (purchaseAmount >= 5000 && purchaseAmount < 10000)
            {
                segment = "Silver";
            }
            return new Customer { CustomerId = grouping.Key, Segment = segment };
        });
    }
}