namespace Zentrack.Api.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Zentrack.Api.Repositories;
using Zentrack.Api.Services;

public static class Dependency
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();

        // Add Services
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
