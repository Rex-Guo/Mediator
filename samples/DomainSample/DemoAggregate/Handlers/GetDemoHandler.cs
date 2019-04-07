using DomainSample.DemoAggregate.Commands;
using DomainSample.DemoAggregate.Dtos;
using Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainSample.DemoAggregate.Handlers
{
    internal class GetDemoHandler : IHandler<GetDemoCommand, DemoDto>
    {
        private readonly AppDbContext _appDbContext;

        public GetDemoHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<DemoDto> HandleAsync(GetDemoCommand command, CancellationToken token)
        {
            var demo = await _appDbContext.Demo.FindAsync(command.Id);

            if (demo == null) throw new Exception("not find demo");

            return new DemoDto
            {
                Name = demo.Name
            };
        }
    }
}