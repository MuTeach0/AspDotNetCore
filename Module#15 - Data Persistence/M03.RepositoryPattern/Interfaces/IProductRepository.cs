
using M03.RepositoryPattern.Models;

namespace M03.RepositoryPattern.Interfaces;

public interface IProductRepository
{
    Task<bool> AddProductAsync(Product product);
    Task<bool> AddProductReviewAsync(ProductReview review);
    Task<bool> DeleteProductAsync(Guid id);
    Task<bool> ExistsByIdAsync(Guid id);
    Task<bool> ExistsByNameAsync(string? name);
    Task<List<Product>> GetAllProductsPageAsync(int page = 1, int pageSize = 10);
    Task<Product?> GetProductByIdAsync(Guid id);
    Task<List<ProductReview>> GetProductReviewsAsync(Guid productId);
    Task<int> GetProductsCountAsync();
    Task<ProductReview?> GetReviewAsync(Guid productId, Guid reviewId);
    Task<bool> UpdateProductAsync(Product updateProduct);
}