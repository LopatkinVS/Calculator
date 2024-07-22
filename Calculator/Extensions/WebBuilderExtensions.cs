using Calculator.BI.Interfaces;
using Calculator.BI.Services;
using Calculator.Data.Interfaces;
using Calculator.Data.Repositories;
using System.Diagnostics.Contracts;

namespace Calculator.Extensions
{
    public static class WebBuilderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICalculateNumberRepository, CalculateNumberRepository>();

            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICalculateService, CalculateService>();

            return services;
        }
    }
}
