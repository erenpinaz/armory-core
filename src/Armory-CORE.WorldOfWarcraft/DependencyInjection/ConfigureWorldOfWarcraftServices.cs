using Microsoft.Extensions.DependencyInjection;

namespace Armory_CORE.Core.WorldOfWarcraft.DependencyInjection
{
    public static class ConfigureWorldOfWarcraftServices
    {
        /// <summary>
        /// Adds World of Warcraft api services. Requires base api services to be added. />
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWorldOfWarcraftApiServices(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<WorldOfWarcraftApi>();

            return services;
        }
    }
}
