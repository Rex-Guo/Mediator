using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    public class NotHandlerException : Exception
    {
        public NotHandlerException() : base("not find handler")
        {
        }
    }
}