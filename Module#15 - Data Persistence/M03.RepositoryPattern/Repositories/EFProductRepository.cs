using System.Threading.Tasks;
using M03.RepositoryPattern.Interfaces;
using M03.RepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace M03.RepositoryPattern.Data;

public class EFProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<int> GetProductsCountAsync() => await context.Products.CountAsync();
    public async Task<List<Product>> GetAllProductsPageAsync(int page = 1, int pageSize = 10)
    {
        var products = await context.Products.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return products;
    }

    public async Task<Product?> GetProductByIdAsync(Guid id) =>
        await context.Products.FirstOrDefaultAsync(p => p.Id == id) ?? null;

    public async Task<List<ProductReview>> GetProductReviewsAsync(Guid productId) =>
        await context.ProductReviews.Where(r => r.ProductId == productId).ToListAsync();

    public async Task<ProductReview?> GetReviewAsync(Guid productId, Guid reviewId) =>
        await context.ProductReviews.FirstOrDefaultAsync(r => r.ProductId == productId && r.Id == reviewId);

    public async Task<bool> AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddProductReviewAsync(ProductReview review)
    {
        if (!context.Products.Any(p => p.Id == review.ProductId))
            return false;
        context.ProductReviews.Add(review);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateProductAsync(Product updateProduct)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == updateProduct.Id);
        if (existingProduct is null)
            return false;

        existingProduct.Name = updateProduct.Name;
        existingProduct.Price = updateProduct.Price;
        return context.SaveChanges() > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            return false;

        context.Products.Remove(product);

        return context.SaveChanges() > 0;
    }

    public async Task<bool> ExistsByIdAsync(Guid id) => await context.Products.AnyAsync(p => p.Id == id);

    public async Task<bool> ExistsByNameAsync(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        // return await context.Products.AnyAsync(p => p.Name.ToLower() == name.ToLower()); // Exact match, case insensitive slow

        // SQL LIKE match, case insensitive faster
        return await context.Products.AnyAsync(p => EF.Functions.Like(p.Name!.ToUpper(), name.ToUpper()));
    }
}