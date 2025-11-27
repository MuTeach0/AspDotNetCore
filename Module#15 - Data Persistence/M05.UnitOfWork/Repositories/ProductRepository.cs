using M05.UnitOfWork.Interfaces;
using M05.UnitOfWork.Models;
using Microsoft.EntityFrameworkCore;

namespace M05.UnitOfWork.Data;

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

    public void AddProduct(Product product) => context.Products.Add(product);

    public async Task AddProductReviewAsync(ProductReview review, CancellationToken ct = default)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == review.ProductId, ct) ??
            throw new InvalidOperationException();

        await context.ProductReviews.AddAsync(review, ct);

        var reviews = await context.ProductReviews
            .Where(pr => pr.ProductId == review.ProductId)
            .ToListAsync(ct);

        product.AverageRating = (decimal)Math.Round(reviews.Average(pr => pr.Stars), 1, MidpointRounding.AwayFromZero);
    }

    public async Task UpdateProductAsync(Product updateProduct, CancellationToken ct = default)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == updateProduct.Id, ct)
            ?? throw new InvalidOperationException();
        existingProduct.Name = updateProduct.Name;
        existingProduct.Price = updateProduct.Price;
    }

    public async Task DeleteProductAsync(Guid id, CancellationToken ct = default)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, ct)
            ?? throw new InvalidOperationException();

        context.Products.Remove(product);
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