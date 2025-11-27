using System.Threading.Tasks;
using M04.CancellationTokenBenefit.Interfaces;
using M04.CancellationTokenBenefit.Models;
using Microsoft.EntityFrameworkCore;

namespace M04.CancellationTokenBenefit.Data;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<int> GetProductsCountAsync(CancellationToken ct = default)
        => await context.Products.CountAsync(ct);

    public async Task<List<Product>> GetAllProductsPageAsync(
        int page = 1,
        int pageSize = 10,
        CancellationToken ct = default)
    {
        return await context.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken ct = default) =>
        await context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<List<ProductReview>> GetProductReviewsAsync(Guid productId, CancellationToken ct = default) =>
        await context.ProductReviews.Where(r => r.ProductId == productId).ToListAsync(ct);

    public async Task<ProductReview?> GetReviewAsync(Guid productId, Guid reviewId, CancellationToken ct = default) =>
        await context.ProductReviews.FirstOrDefaultAsync(r => r.ProductId == productId && r.Id == reviewId, ct);

    public async Task<bool> AddProductAsync(Product product, CancellationToken ct = default)
    {
        await context.Products.AddAsync(product, ct);
        return await context.SaveChangesAsync(ct) > 0;
    }

    public async Task<bool> AddProductReviewAsync(ProductReview review, CancellationToken ct = default)
    {
        if (!await context.Products.AnyAsync(p => p.Id == review.ProductId, ct))
            return false;

        await context.ProductReviews.AddAsync(review, ct);
        return await context.SaveChangesAsync(ct) > 0;
    }

    public async Task<bool> UpdateProductAsync(Product updateProduct, CancellationToken ct = default)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == updateProduct.Id, ct);
        if (existingProduct is null)
            return false;

        existingProduct.Name = updateProduct.Name;
        existingProduct.Price = updateProduct.Price;
        return await context.SaveChangesAsync(ct) > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid id, CancellationToken ct = default)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, ct);
        if (product is null)
            return false;

        context.Products.Remove(product);
        return await context.SaveChangesAsync(ct) > 0;
    }

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default)
        => await context.Products.AnyAsync(p => p.Id == id, ct);

    public async Task<bool> ExistsByNameAsync(string? name, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        return await context.Products.AnyAsync(
            p => EF.Functions.Like(p.Name!.ToUpper(), name.ToUpper()), ct);
    }
}