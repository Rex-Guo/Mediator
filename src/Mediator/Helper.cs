using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mediator
{
    internal static class Helper
    {
        internal static Dictionary<Type, HandlerTypeInfo> GetCommandHandlerDictionary(Assembly[] assemblies)
        {
            var handerGUIDs = new[] {
                typeof(IHandler<,>).GUID,
                typeof(IHandler<>).GUID
            };

            if (assemblies.Count() == 0) assemblies = new[] { Assembly.GetEntryAssembly() };

            var dic = new Dictionary<Type, HandlerTypeInfo>();

            foreach (TypeInfo item in assemblies.SelectMany(s => s.GetTypes()))
            {
                var @interface = item.ImplementedInterfaces.FirstOrDefault(f => handerGUIDs.Contains(f.GUID));
                if (@interface != null)
                {
                    var cmd = @interface.GenericTypeArguments[0];
                    if (dic.TryGetValue(cmd, out _)) continue;
                    var method = @interface.GetMethods()[0];
                    dic.Add(cmd, new HandlerTypeInfo(item, method));
                }
            }

            return dic;
        }
    }
}