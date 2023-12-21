using AutoMapper;
using RestApiTemplate.Repositories.IRepositories;
using RestApiTemplate.Services.IServices;

namespace RestApiTemplate.Services;

public class ServiceManager : IServiceManager
{
    
    // add services lazy loaders here
    
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        // inject services here
    }
    
    // add services return .value here
}