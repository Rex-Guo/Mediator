using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IDispather
    {
        Task<TResult> DispathAsync<TResult>(ICommand<TResult> command, CancellationToken token = default);

        Task DispathAsync(ICommand command, CancellationToken token = default);
    }
}