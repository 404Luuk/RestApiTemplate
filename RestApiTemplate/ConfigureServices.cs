using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using RestApiTemplate.Persistence;

namespace RestApiTemplate;

public static class ConfigureServices
{
    public static async Task<IServiceCollection> AddServices(this IServiceCollection services)
    {

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(""); //TODO: inject connection string here
        var connectionString = dataSourceBuilder.ConnectionString;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string is null or empty.");
        }
        
        await using var dataSource = dataSourceBuilder.Build();
        
        services.AddDbContext<ApplicationDbContext>(options
            => options.UseNpgsql(connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                }));
        
        // Reconfigure to spec
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        //add service lifetimes here
        
        //services.AddAutoMapper(typeof( TODO: Add MappingProfile.cs here)); 
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}