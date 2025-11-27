using M01.CachingInMemory.Requests;
using M01.CachingInMemory.Responses;

namespace M01.CachingInMemory.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<List<ProductResponse>> GetProductsAsync();
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
