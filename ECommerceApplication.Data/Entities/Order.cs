namespace ECommerceApplication.Data.Entities;

public class Order(string orderId, string customerId, List<Product> products, DateTime purchaseTime)
{
    public string OrderId { get; set; } = orderId;
    public string CustomerId { get; set; } = customerId;
    public List<Product> Products { get; set; } = products;
    public DateTime PurchaseTime { get; set; } = purchaseTime;
}
