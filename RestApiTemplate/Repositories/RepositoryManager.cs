using RestApiTemplate.Persistence;
using RestApiTemplate.Repositories.IRepositories;

namespace RestApiTemplate.Repositories;

public class RepositoryManager: IRepositoryManager
{ 
    private readonly ApplicationDbContext? _repositoryContext;
    // add repositories lazy loaders here
    
    public RepositoryManager(ApplicationDbContext repositoryContext)
    {
        // inject repositories here
        _repositoryContext = repositoryContext;
    }
    
    // add repositories return .value here
    
    public async Task SaveAsync()
    {
        await _repositoryContext!.SaveChangesAsync();
    }
}