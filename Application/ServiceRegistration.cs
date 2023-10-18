using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddMediatR(FromAssemblies());

        private static Action<MediatRServiceConfiguration> FromAssemblies()
            => cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    }
}
