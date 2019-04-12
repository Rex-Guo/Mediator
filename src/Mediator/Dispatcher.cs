using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IReadOnlyDictionary<Type, HandlerTypeInfo> _dic;

        public Dispatcher(IServiceProvider serviceProvider, Dictionary<Type, HandlerTypeInfo> dic)
        {
            _serviceProvider = serviceProvider;
            _dic = dic;
        }

        public Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken token = default)
        {
            bool success = _dic.TryGetValue(command.GetType(), out var handlerType);
            if (!success) throw new NotHandlerException();
            object handler = _serviceProvider.GetService(handlerType.Type);

            return (Task<TResult>)handlerType.Method.Invoke(handler, new object[] { command, token, this });

            //var call = Expression.Call(
            //    Expression.Constant(handler),
            //    handlerType.Method,
            //    Expression.Constant(command),
            //    Expression.Constant(token),
            //    Expression.Constant(this));
        }

        public Task DispatchAsync(ICommand command, CancellationToken token = default) => DispatchAsync(command, token);
    }
}