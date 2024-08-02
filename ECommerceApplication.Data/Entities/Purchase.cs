namespace ECommerceApplication.Data.Entities;

public class Purchase
{
    public required string CustomerId { get; init; }
    public double Amount { get; init; }
    public DateTime PurchaseDate { get; init; }
}
