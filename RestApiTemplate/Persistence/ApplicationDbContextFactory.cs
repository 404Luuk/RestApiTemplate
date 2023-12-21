using Microsoft.EntityFrameworkCore;

namespace RestApiTemplate.Persistence;

public class ApplicationDbContextFactory
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(""); // inject connection string here

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}