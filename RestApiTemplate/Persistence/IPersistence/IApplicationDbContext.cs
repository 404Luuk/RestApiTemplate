namespace RestApiTemplate.Persistence.IPersistence;

public interface IApplicationDbContext
{
    // add dbsets here
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}