using System.Net.Http.Json;
using System.Text.Json.Nodes;
using ECommerceApplication.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerceApplication.Test;

public class Question1(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory = factory;

    [Fact]
    public async Task Question1Test()
    {
        // Arrange
        var client = this.factory.CreateClient();

        // Act
        var result = await client.GetFromJsonAsync<JsonArray>("/products/partner?limit=5");

        // Assert
        Assert.Equal(5, result!.Count);
        Assert.Equal(3, result![1]!.AsObject().Count);
        Assert.Equal(22.3m, result![1]!["price"]!.GetValue<decimal>());
        Assert.Equal("Mens Casual Premium Slim Fit T-Shirts ", result![1]!["title"]!.GetValue<string>());
        Assert.Equal("Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.", result![1]!["description"]!.GetValue<string>());
    }
}
