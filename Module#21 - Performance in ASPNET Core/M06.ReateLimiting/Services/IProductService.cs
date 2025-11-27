using M06.RateLimiting.Models;
using M06.RateLimiting.Requests;
using M06.RateLimiting.Responses;

namespace M06.RateLimiting.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<PageResult<ProductResponse>> GetProductsAsync(int page = 1, int pageSize = 10);
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
