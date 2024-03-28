using GymManagement.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application
{
    public static class DependacyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ISubscriptionServive, SubscriptionService>();

            return services;
        }
    }
}
