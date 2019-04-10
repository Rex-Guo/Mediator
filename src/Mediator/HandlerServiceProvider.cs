using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mediator
{
    internal class HandlerServiceProvider : IServiceProvider
    {
        private static readonly Type[] _types = new Type[0];
        private static readonly object[] _objects = new object[0];

        public object GetService(Type serviceType)
        {
            return serviceType.GetConstructor(_types).Invoke(_objects);
        }
    }
}