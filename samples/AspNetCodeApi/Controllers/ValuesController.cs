using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public ValuesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync([FromQuery]TestCommand command)
        {
            return await _dispatcher.DispatchAsync(command, HttpContext.RequestAborted);
        }
    }
}