using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ICityBusProxy _busRouteProxy;

        public TestController(ICityBusProxy busRouteProxy)
        {
            _busRouteProxy = busRouteProxy;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _busRouteProxy.GetBusStopAsync("Taipei");
            return Ok(data);
        }
    }
}