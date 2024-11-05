using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Infrastructure.Data;
using System;

namespace PatientManagement.Infrastructure
{
    /// <summary>
    /// Static class for configuring dependency injection in the infrastructure layer.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures services for dependency injection in the infrastructure layer.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        /// <param name="configuration">The configuration settings.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with connection string from DatabaseConnectionService
            services.AddDbContext<PatientManagementDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
