using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mediator
{
    public static class Helper
    {
        public static Dictionary<Type, Type> GetCommandHandlerDictionary(Assembly[] assemblies)
        {
            var handerGUIDs = new[] {
                typeof(IHandler<,>).GUID,
                typeof(IHandler<>).GUID
            };

            if (assemblies.Count() == 0) assemblies = new[] { Assembly.GetEntryAssembly() };

            return assemblies.SelectMany(s => s.GetTypes())
               .Cast<TypeInfo>()
               .Where(w => w.ImplementedInterfaces.Any(a => handerGUIDs.Contains(a.GUID)))
               .ToDictionary(
                t => t.ImplementedInterfaces.First(f => handerGUIDs.Contains(f.GUID)).GenericTypeArguments[0],
                t => (Type)t);
        }
    }
}