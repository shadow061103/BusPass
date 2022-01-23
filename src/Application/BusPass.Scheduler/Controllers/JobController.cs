using BusPass.Scheduler.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Scheduler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase

    {
        /// <summary>
        /// 啟動排程工作
        /// </summary>
        [HttpPost]
        public void CalDealRent()
        {
            BackgroundJob.Enqueue<IBusInitialJob>(c => c.DataInitialCreateJob(null));
        }
    }
}