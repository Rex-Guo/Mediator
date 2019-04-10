using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PerformanceComparisonWithMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly IMediator _mediator;

        public ValuesController(IDispatcher dispatcher, IMediator mediator)
        {
            _dispatcher = dispatcher;
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<string> Mediator([FromQuery] TestCommand testCommand)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                await _dispatcher.DispatchAsync(testCommand);
            }
            sw.Stop();
            return sw.Elapsed.ToString();
        }

        [HttpGet("[action]")]
        public async Task<string> MediatR([FromQuery] TestCommand testCommand)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                await _mediator.Send(testCommand);
            }
            sw.Stop();
            return sw.Elapsed.ToString();
        }
    }
}