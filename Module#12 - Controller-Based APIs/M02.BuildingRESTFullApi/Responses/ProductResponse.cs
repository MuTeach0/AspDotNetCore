using M02.BuildingRESTFullApi.Models;

namespace M02.BuildingRESTFullApi.Responses;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public List<ProductReviewResponse>? Reviews { get; set; } = default;
    private ProductResponse() { }
    public static ProductResponse FromModel(Product product, IEnumerable<ProductReview>? reviews = null)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product), "Cannot create a response from a null product.");

        var response = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

        if (reviews is not null)
            response.Reviews = [.. ProductReviewResponse.FromModelList(reviews)];

        return response;
    }

    public static IEnumerable<ProductResponse> FromModels(IEnumerable<Product> products)
        => products is null ?
        throw new ArgumentNullException(nameof(products), "Cannot create a response from a null product.") :
        products.Select(p => FromModel(p));
}