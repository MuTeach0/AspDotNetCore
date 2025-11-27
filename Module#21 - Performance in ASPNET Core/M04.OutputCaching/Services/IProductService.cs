using M04.OutputCaching.Models;
using M04.OutputCaching.Requests;
using M04.OutputCaching.Responses;

namespace M04.OutputCaching.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<PageResult<ProductResponse>> GetProductsAsync(int page = 1, int pageSize = 10);
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
