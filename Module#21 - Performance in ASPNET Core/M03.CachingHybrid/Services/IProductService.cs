using M03.CachingHybrid.Requests;
using M03.CachingHybrid.Responses;

namespace M03.CachingHybrid.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<List<ProductResponse>> GetProductsAsync();
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
