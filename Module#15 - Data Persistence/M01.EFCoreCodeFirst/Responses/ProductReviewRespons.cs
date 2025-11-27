using M01.EFCoreCodeFirst.Models;

namespace M01.EFCoreCodeFirst.Responses;

public class ProductReviewResponse
{
    public Guid ReviewId { get; set; }
    public Guid ProductId { get; set; }
    public string? Reviewer { get; set; }
    public int Stars { get; set; }
    private ProductReviewResponse() { }

    public static ProductReviewResponse FromModel(ProductReview? review)
    {
        if (review is null)
            throw new ArgumentNullException(nameof(review), "Cannot create a response from a null review.");

        return new ProductReviewResponse
        {
            ReviewId = review.Id,
            ProductId = review.ProductId,
            Reviewer = review.Reviewer,
            Stars = review.Stars
        };
    }

    public static IEnumerable<ProductReviewResponse> FromModelList(IEnumerable<ProductReview> reviews)
        => reviews is null ?
           throw new ArgumentNullException(nameof(reviews)) :
           reviews.Select(FromModel);

}