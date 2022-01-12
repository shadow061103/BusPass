using BusPass.Repository.Infrastructure.Helpers;
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
        private readonly IApiHelper _apiHelper;

        public TestController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Bus/Stop/City/NewTaipei?%24top=30&%24format=JSON";
            var data = await _apiHelper.GetPTXAsync<string>(url);
            return Ok(data);
        }
    }
}