using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Persistence.IPersistence;

namespace RestApiTemplate.Persistence;

public class ApplicationDbContext : DbContext , IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    // add dbsets here
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        // add fluent api here
        
        base.OnModelCreating(modelBuilder);
    }
}