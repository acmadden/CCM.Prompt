using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ECommerceApplication.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerceApplication.Test;

public class Question2(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory = factory;

    [Fact]
    public async Task Question2Test()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<JsonArray>("/products/top-pairs?topN=5");

        // Assert
        Assert.Equal(5, result!.Count);
        Assert.Equal(2, result![0]!.AsObject().Count);
        Assert.Equal(2, result![0]!["products"]!.AsArray().Count);
        Assert.Equal(2, result![1]!["products"]!.AsArray().Count);
        Assert.Equal(3, result![0]!["frequency"]!.GetValue<int>());
        Assert.True(result![0]!["products"]!.AsArray().All(p => new[] { "Running Shoes", "Socks" }.Contains(p.GetValue<string>())));
    }
}
