using Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCodeApi
{
    public class TestHandler : IHandler<TestCommand, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> HandleAsync(TestCommand command, CancellationToken token)
        {
            return await Task.FromResult(new string[] { "value1", "value2" });
        }
    }
}