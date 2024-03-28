using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application
{
    public static class DependacyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(DependacyInjection));
            });

            return services;
        }
    }
}
