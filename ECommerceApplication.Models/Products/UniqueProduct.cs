namespace Application.Models;

public sealed class UniqueProduct
{
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public required string Category { get; set; }
}