using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken token = default);

        Task DispatchAsync(ICommand command, CancellationToken token = default);
    }
}