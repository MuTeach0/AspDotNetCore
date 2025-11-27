using M02.CachingDistributed.Requests;
using M02.CachingDistributed.Responses;

namespace M02.CachingDistributed.Services;

public interface IProductService
{
    Task<ProductResponse> AddProductAsync(CreateProductRequest request);
    Task<ProductResponse?> GetProductByIdAsync(int productId);
    Task<List<ProductResponse>> GetProductsAsync();
    Task UpdateProductAsync(int productId, UpdateProductRequest request);
    Task DeleteProductAsync(int id);
}
