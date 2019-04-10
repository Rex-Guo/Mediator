using Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basic
{
    public class TestHandler : IHandler<TestCommand, string>
    {
        public Task<string> HandleAsync(TestCommand command, CancellationToken token, IDispatcher dispatcher)
        {
            return Task.FromResult($"command payload: {command.Id}");
        }
    }
}