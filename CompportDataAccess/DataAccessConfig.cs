using CompportDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompportDataAccess
{
    public static class DataAccessConfig
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string? connectionString)
        {
            Console.WriteLine(connectionString);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }

}
