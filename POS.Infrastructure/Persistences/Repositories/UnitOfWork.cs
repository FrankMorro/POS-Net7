using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbposContext _context;
    public ICategoryRepository Category { get; private set; } = null!;

    public UnitOfWork(DbposContext context)
    {
        _context = context;
        Category = new CategoryRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
