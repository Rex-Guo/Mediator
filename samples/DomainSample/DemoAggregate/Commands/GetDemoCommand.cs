using DomainSample.DemoAggregate.Dtos;
using Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainSample.DemoAggregate.Commands
{
    public class GetDemoCommand : ICommand<DemoDto>
    {
        public int Id { get; set; }
    }
}