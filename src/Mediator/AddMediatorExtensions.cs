using Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            var handerGUIDs = new[] {
                typeof(IHandler<,>).GUID,
                typeof(IHandler<>).GUID
            };

            if (assemblies.Count() == 0) assemblies = new[] { Assembly.GetCallingAssembly() };

            var handlerTypes = assemblies.SelectMany(s => s.GetTypes())
               .Cast<TypeInfo>()
               .Where(w => w.ImplementedInterfaces.Any(a => handerGUIDs.Contains(a.GUID)));

            foreach (var item in handlerTypes)
            {
                services.AddScoped(item);
            }

            var dic = handlerTypes.ToDictionary(
                t => t.ImplementedInterfaces.First(f => handerGUIDs.Contains(f.GUID)).GenericTypeArguments[0],
                t => (Type)t);

            services.AddScoped<IDispather, Dispather>(provider => new Dispather(provider, dic));
            return services;
        }
    }
}