namespace ECommerceApplication.Data.Entities;

public class Product(string productId, string productName, double price, string category)
{
    public string ProductId { get; set; } = productId;
    public string ProductName { get; set; } = productName;
    public double Price { get; set; } = price;
    public string Category { get; set; } = category;
}
