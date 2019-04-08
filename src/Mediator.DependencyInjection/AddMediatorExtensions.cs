using Mediator;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            var dic = Helper.GetCommandHandlerDictionary(assemblies);
            foreach (var item in dic) services.AddScoped(item.Value.Type);
            services.AddScoped<IDispatcher, Dispatcher>(provider => new Dispatcher(provider, dic));
            return services;
        }
    }
}