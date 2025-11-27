using M05.UnitOfWork.Data;
using M05.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace M05.UnitOfWork.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IProductRepository? _productRepository;
    public IProductRepository Products => _productRepository ??= new ProductRepository(context);


    public void Dispose() => context.Dispose();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}