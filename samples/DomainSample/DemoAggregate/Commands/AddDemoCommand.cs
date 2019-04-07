using Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainSample.DemoAggregate.Commands
{
    public class AddDemoCommand : ICommand
    {
        public string Name { get; set; }
    }
}