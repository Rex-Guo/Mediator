using DomainSample.DemoAggregate.Commands;
using Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainSample.DemoAggregate.Handlers
{
    internal class AddDemoHandler : IHandler<AddDemoCommand>
    {
        private readonly AppDbContext _appDbContext;

        public AddDemoHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task HandleAsync(AddDemoCommand command, CancellationToken token)
        {
            var demo = new Demo(command.Name);
            _appDbContext.Demo.Add(demo);
            await _appDbContext.SaveChangesAsync(token);
        }
    }
}