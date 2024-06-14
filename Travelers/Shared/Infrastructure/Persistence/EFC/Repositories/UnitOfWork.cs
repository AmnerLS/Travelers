using Travelers.Shared.Domain.Repositories;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Travelers.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;
    
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}