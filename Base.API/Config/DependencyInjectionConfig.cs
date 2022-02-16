using Base.Domain.Intefaces.Services;
using Base.Domain.Services;
using Base.Infrastructure.Interfaces.Repositories;
using Base.Infrastructure.Repositories;

namespace Base.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            ResolveServices(services);
            ResolveRepositories(services);
        }

        private static void ResolveServices(IServiceCollection services)
        {
            services.AddScoped<IServiceTodo, ServiceTodo>();
        }

        private static void ResolveRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryTodo, RepositoryTodo>();
        }
    }
}
