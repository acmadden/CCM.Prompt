using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ECommerceApplication.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerceApplication.Test;

public class Question4(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory = factory;

    [Fact]
    public async Task Question4Test()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<JsonArray>("/customers/segment");

        // Assert
        Assert.Equal(4, result!.Count);
        Assert.Equal("Silver", result.First(p => p["customerId"]!.GetValue<string>() == "C001")!["segment"]!.GetValue<string>());
        Assert.Equal("Bronze", result.First(p => p["customerId"]!.GetValue<string>() == "C003")!["segment"]!.GetValue<string>());
    }
}
