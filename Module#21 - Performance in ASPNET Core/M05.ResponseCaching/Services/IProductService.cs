using M05.ResponseCaching.Models;
using M05.ResponseCaching.Requests;
using M05.ResponseCaching.Responses;

namespace M05.ResponseCaching.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<PageResult<ProductResponse>> GetProductsAsync(int page = 1, int pageSize = 10);
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
