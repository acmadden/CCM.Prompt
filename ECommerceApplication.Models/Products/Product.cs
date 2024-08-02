using System.Text.Json.Serialization;

namespace Application.Models;

public sealed class Product
{
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public required string Description { get; set; }
}
