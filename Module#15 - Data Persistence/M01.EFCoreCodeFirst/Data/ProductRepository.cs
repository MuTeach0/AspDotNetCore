using M01.EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace M01.EFCoreCodeFirst.Data;

public class ProductRepository(AppDbContext context)
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

    public bool AddProduct(Product product)
    {
        context.Products.Add(product);
        return context.SaveChanges() > 0;
    }

    public async Task<bool> AddProductReviewAsync(ProductReview review)
    {
        if (!context.Products.Any(p => p.Id == review.ProductId))
            return false;
        context.ProductReviews.Add(review);
        return await context.SaveChangesAsync() > 0;
    }

    public bool UpdateProduct(Product updateProduct)
    {
        var existingProduct = context.Products.FirstOrDefault(p => p.Id == updateProduct.Id);
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

    public bool ExistsById(Guid id) => context.Products.Any(p => p.Id == id);

    public bool ExistsByName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        // return context.Products.Any(p => p.Name.ToLower() == name.ToLower()); // Exact match, case insensitive slow

        return context.Products.Any(p => EF.Functions.Like(p.Name!.ToUpper(), name.ToUpper())); // SQL LIKE match, case insensitive faster
    }
}