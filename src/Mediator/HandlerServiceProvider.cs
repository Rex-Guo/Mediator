using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mediator
{
    internal class HandlerServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return Expression.Lambda(Expression.New(serviceType)).Compile().DynamicInvoke();
        }
    }
}