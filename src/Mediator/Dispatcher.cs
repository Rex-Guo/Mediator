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
        private readonly IReadOnlyDictionary<Type, Type> _dic;

        public Dispatcher(IServiceProvider serviceProvider, Dictionary<Type, Type> dic)
        {
            _serviceProvider = serviceProvider;
            _dic = dic;
        }

        public Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken token = default)
        {
            bool success = _dic.TryGetValue(command.GetType(), out var handlerType);
            if (!success) throw new NotHandlerException();
            object handler = _serviceProvider.GetService(handlerType);

            var call = Expression.Call(
                Expression.Constant(handler),
                handlerType.GetMethod("HandleAsync"),
                Expression.Constant(command),
                Expression.Constant(token));

            return (Task<TResult>)Expression.Lambda(call).Compile().DynamicInvoke();
        }

        public Task DispatchAsync(ICommand command, CancellationToken token = default) => DispatchAsync(command, token);
    }
}