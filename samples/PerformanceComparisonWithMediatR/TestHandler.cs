using Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceComparisonWithMediatR
{
    public class TestHandler : IHandler<TestCommand, string>, IRequestHandler<TestCommand, string>
    {
        public Task<string> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            return Handle(request);
        }

        public Task<string> HandleAsync(TestCommand command, CancellationToken token, IDispatcher dispatcher)
        {
            return Handle(command);
        }

        private static Task<string> Handle(TestCommand command)
        {
            return Task.FromResult($"command payload: {command.Id}");
        }
    }
}