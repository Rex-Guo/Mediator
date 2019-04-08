using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mediator
{
    public class DispatchBuilder
    {
        private readonly Dictionary<Type, HandlerTypeInfo> _dic;
        private readonly IServiceProvider _serviceProvider;

        public DispatchBuilder(params Assembly[] assemblies)
        {
            _dic = Helper.GetCommandHandlerDictionary(assemblies);
            _serviceProvider = new HandlerServiceProvider();
        }

        public IDispatcher Build()
        {
            return new Dispatcher(_serviceProvider, _dic);
        }
    }
}