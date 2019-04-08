using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mediator
{
    internal class HandlerTypeInfo
    {
        public HandlerTypeInfo(TypeInfo type, MethodInfo method)
        {
            Type = type;
            Method = method;
        }

        public TypeInfo Type { get; private set; }

        public MethodInfo Method { get; private set; }
    }
}