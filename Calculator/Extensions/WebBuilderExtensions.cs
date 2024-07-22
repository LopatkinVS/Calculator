using Calculator.Data.Interfaces;
using Calculator.Data.Repositories;

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
    }
}
