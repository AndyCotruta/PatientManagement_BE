using Microsoft.Extensions.DependencyInjection;

namespace PatientManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly; // Get the assembly of this class

            // Register MediatR handlers and behaviors from the assembly
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            return services; // Return the modified service collection
        }           
    }
}
