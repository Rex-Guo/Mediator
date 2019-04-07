using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainSample.DemoAggregate.Commands;
using DomainSample.DemoAggregate.Dtos;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDispather _dispather;

        public DemoController(IDispather dispather)
        {
            _dispather = dispather;
        }

        [HttpPost]
        public Task Post([FromBody]AddDemoCommand command) => _dispather.DispathAsync(command, HttpContext.RequestAborted);

        [HttpGet]
        public Task<DemoDto> Get([FromQuery]GetDemoCommand command) => _dispather.DispathAsync(command, HttpContext.RequestAborted);
    }
}