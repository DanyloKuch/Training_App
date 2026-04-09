using Training_App.Domain.Abstraction;

namespace Training_App.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly TrainingAppDbContext _context;

    public UnitOfWork(TrainingAppDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}