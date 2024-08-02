namespace Application.Models;

public sealed class ProductPair
{
    public required IEnumerable<string> Products { get; set; }
    public required int Frequency { get; set; }
}