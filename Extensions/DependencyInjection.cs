using Microsoft.Extensions.DependencyInjection;

namespace Cloud.Middleware.Extensions
{
    //Adding DI for making it available through nuget package, later plug and play!
    public static class DependencyInjection
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            return services;
        }
    }
}