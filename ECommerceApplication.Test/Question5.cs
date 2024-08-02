using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ECommerceApplication.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerceApplication.Test;

public class Question5(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory = factory;

    [Fact]
    public async Task Question5Test()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<JsonArray>("/products/unique?year=2023");

        // Assert
        Assert.Equal(14, result!.Count);
        Assert.Equal(3, result![1]!.AsObject().Count);
        Assert.True(result.All(p => new[] { "P001", "P002", "P003", "P004", "P005", "P006", "P013", "P012", "P016", "P017", "P007", "P008", "P018", "P019" }.Contains(p!["productId"]!.GetValue<string>())));
    }
}
