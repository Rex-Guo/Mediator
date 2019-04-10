using Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceComparisonWithMediatR
{
    public class TestCommand : ICommand<string>, IRequest<string>
    {
        public int Id { get; set; }
    }
}