using System.Data;
using System.Threading.Tasks;
using Dapper;
using M02.Dapper.Models;

namespace M02.Dapper.Data;

public class ProductRepository(IDbConnection _db)
{
    // #region In memory Products and Reviews
    // private List<Product> _products =
    // [
    //     new Product { Id = Guid.Parse("2779ee47-10b0-4bd7-8342-404006aa1392"), Name = "Soda", Price = 1.99m },
    //     new Product { Id = Guid.Parse("27a65726-a07f-484c-9b0c-334611ec1c18"), Name = "Milk", Price = 3.49m },
    //     new Product { Id = Guid.Parse("69a0b1fe-3c20-4a4a-bc57-13a8078d8e00"), Name = "Juice", Price = 4.75m },
    //     new Product { Id = Guid.Parse("8fa9f2a4-1b8a-4e66-ae9b-1234567890ab"), Name = "Bread", Price = 2.49m },
    //     new Product { Id = Guid.Parse("2f8b4f29-4d8f-49c1-86f2-234567890abc"), Name = "Butter", Price = 3.99m },
    //     new Product { Id = Guid.Parse("5e76a48d-0e75-4e23-9bcd-34567890abcd"), Name = "Eggs", Price = 2.99m },
    //     new Product { Id = Guid.Parse("7d2f3b91-3f2d-4f0a-92c1-4567890abcde"), Name = "Cheese", Price = 5.49m },
    //     new Product { Id = Guid.Parse("9a4c7e3f-5b2d-4e9c-bcde-567890abcdef"), Name = "Chocolate", Price = 1.99m },
    //     new Product { Id = Guid.Parse("3c9f3f00-2b1e-4a3b-a7f9-67890abcdef0"), Name = "Coffee", Price = 7.99m },
    //     new Product { Id = Guid.Parse("d5e8f1a2-3c4d-4b5e-89ab-7890abcdef12"), Name = "Tea", Price = 4.99m },
    //     new Product { Id = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-890abcdef123"), Name = "Water", Price = 0.99m },
    //     new Product { Id = Guid.Parse("2b3c4d5e-6f7a-8b9c-0d1e-90abcdef1234"), Name = "Fruit Juice", Price = 3.99m },
    //     new Product { Id = Guid.Parse("3c4d5e6f-7a8b-9c0d-1e2f-abcdef123456"), Name = "Yogurt", Price = 2.99m },
    //     new Product { Id = Guid.Parse("4d5e6f7a-8b9c-0d1e-2f3a-bcdef1234567"), Name = "Cereal", Price = 4.49m },
    //     new Product { Id = Guid.Parse("5e6f7a8b-9c0d-1e2f-3a4b-cdef12345678"), Name = "Rice", Price = 6.99m },
    //     new Product { Id = Guid.Parse("6f7a8b9c-0d1e-2f3a-4b5c-def123456789"), Name = "Pasta", Price = 3.49m },
    //     new Product { Id = Guid.Parse("7a8b9c0d-1e2f-3a4b-5c6d-ef1234567890"), Name = "Apple", Price = 0.79m },
    //     new Product { Id = Guid.Parse("8b9c0d1e-2f3a-4b5c-6d7e-1234567890ab"), Name = "Banana", Price = 0.59m },
    //     new Product { Id = Guid.Parse("9c0d1e2f-3a4b-5c6d-7e8f-234567890abc"), Name = "Orange", Price = 0.99m },
    //     new Product { Id = Guid.Parse("abcdef12-3456-7890-abcd-ef1234567890"), Name = "Grapes", Price = 2.99m },
    // ];
    // private List<ProductReview> _reviews =
    // [
    //     new ProductReview { Id = Guid.Parse("ddd4e07a-4772-47f7-9cba-6bfc07c26bfe"), ProductId = Guid.Parse("2779ee47-10b0-4bd7-8342-404006aa1392"), Reviewer = "John Doe", Stars = 4 },
    //     new ProductReview { Id = Guid.Parse("c30d9647-1603-4948-8266-88a850547be0"), ProductId = Guid.Parse("2779ee47-10b0-4bd7-8342-404006aa1392"), Reviewer = "Sarah Peter", Stars = 3 },
    // ];
    // #endregion

    public async Task<int> GetProductsCountAsync() => await _db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Products;");
    public async Task<List<Product>> GetAllProductsPageAsync(int page = 1, int pageSize = 10)
    {
        var products = await _db.QueryAsync<Product>(
            "SELECT * FROM Products LIMIT @PageSize OFFSET @Offset;",
            new { PageSize = pageSize, Offset = (page - 1) * pageSize }
        );

        return [.. products];
    }

    public async Task<Product?> GetProductByIdAsync(Guid id) =>
        await _db.QuerySingleOrDefaultAsync<Product>(
            "SELECT * FROM Products WHERE Id = @Id;",
            new { Id = id.ToString() }
        );

    public async Task<List<ProductReview>> GetProductReviewsAsync(Guid productId) =>
        [.. (await _db.QueryAsync<ProductReview>(
            "SELECT * FROM ProductReviews WHERE ProductId = @ProductId;",
            new { ProductId = productId.ToString() }
        )).ToList()];

    public async Task<ProductReview?> GetReviewAsync(Guid productId, Guid reviewId) =>
        await _db.QuerySingleOrDefaultAsync<ProductReview>(
            "SELECT * FROM ProductReviews WHERE ProductId = @ProductId AND Id = @ReviewId;",
            new { ProductId = productId.ToString(), ReviewId = reviewId.ToString() }
        );

    public async Task<bool> AddProductAsync(Product product)
    {
        if (await ExistsByIdAsync(product.Id) || await ExistsByNameAsync(product.Name))
            return false;

        var rowsAffected = await _db.ExecuteAsync(
            "INSERT INTO Products (Id, Name, Price) VALUES (@Id, @Name, @Price);",
            new { product.Id, product.Name, product.Price }
        );

        return rowsAffected > 0;
    }

    public async Task<bool> AddProductReviewAsync(ProductReview review)
    {
        if (await GetProductByIdAsync(review.ProductId) is null)
            return false;

        var rowsAffected = await _db.ExecuteAsync(
            @"INSERT INTO ProductReviews (Id, ProductId, Reviewer, Stars)
            VALUES (@Id, @ProductId, @Reviewer, @Stars);",
            new
            {
                Id = review.Id.ToString(),
                ProductId = review.ProductId.ToString(),
                review.Reviewer,
                review.Stars
            }
        );

        return rowsAffected > 0;
    }

    public async Task<bool> UpdateProductAsync(Product updateProduct)
    {
        var existingProduct = await GetProductByIdAsync(updateProduct.Id);
        if (existingProduct is null)
            return false;

        var rowsAffected = await _db.ExecuteAsync(
            "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id;",
            new { updateProduct.Name, updateProduct.Price, Id = updateProduct.Id.ToString() }
        );

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var existingProduct = await GetProductByIdAsync(id);
        if (existingProduct is null)
            return false;

        var rowsAffected = await _db.ExecuteAsync(
            "DELETE FROM Products WHERE Id = @Id;",
            new { Id = id.ToString() }
        );
        _db.ExecuteAsync(
            "DELETE FROM ProductReviews WHERE ProductId = @ProductId;",
            new { ProductId = id.ToString() }
        );

        return rowsAffected > 0;
    }

    public async Task<bool> ExistsByIdAsync(Guid id) => await _db.ExecuteScalarAsync<int>(
        "SELECT COUNT(1) FROM Products WHERE Id = @Id;",
        new { Id = id.ToString() }
    ) > 0;

    public async Task<bool> ExistsByNameAsync(string? name) => await _db.ExecuteScalarAsync<int>(
        "SELECT COUNT(1) FROM Products WHERE Name = @Name;",
        new { Name = name }
    ) > 0;
}