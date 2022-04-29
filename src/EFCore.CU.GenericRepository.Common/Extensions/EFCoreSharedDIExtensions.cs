
using EFCore.CU.GenericRepository.Common.Persistence;
using EFCore.GenericRepository.Common.Application;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.CU.GenericRepository.Common.Extensions
{

    public static class EFCoreSharedDIExtensions
    {

        public static IServiceCollection AddGenericRepositoryScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,,>),
                typeof(GenericRepository<,,>));
            return services;
        }
        public static IServiceCollection AddGenericRepositoryTransient(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<,,>),
                typeof(GenericRepository<,,>));
            return services;
        }
        public static IServiceCollection AddGenericRepositorySingleton(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericRepository<,,>),
                typeof(GenericRepository<,,>));
            return services;
        }

    }

}