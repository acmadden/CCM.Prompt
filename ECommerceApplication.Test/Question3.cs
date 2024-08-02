using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ECommerceApplication.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerceApplication.Test;

public class Question3(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory = factory;

    [Fact]
    public async Task Question3Test()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<JsonArray>("/sales/analyze");

        // Assert
        Assert.Equal(5, result!.Count);
        Assert.True(result.First(p => p["name"]!.GetValue<string>() == "Laptop")!["consistentHighSales"]!.GetValue<bool>());
        Assert.True(result.Where(p => p["name"]!.GetValue<string>() != "Laptop").All(p => p!["consistentHighSales"]!.GetValue<bool>() == false));
    }
}
