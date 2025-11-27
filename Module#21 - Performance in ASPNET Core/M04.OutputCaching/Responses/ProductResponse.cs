using System.Text.Json.Serialization;
using M04.OutputCaching.Models;

namespace M04.OutputCaching.Responses;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    [JsonConstructor]
    private ProductResponse() { }

    public static ProductResponse FromModel(Product? product) => product is not null ? new ProductResponse
    {
        ProductId = product.Id,
        Name = product.Name,
        Price = product.Price,
    } : throw new ArgumentNullException(nameof(product), "Cannot create a response from a null product");

}
