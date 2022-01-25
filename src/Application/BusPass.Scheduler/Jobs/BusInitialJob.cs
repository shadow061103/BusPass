using BusPass.Common.Enums;
using BusPass.Scheduler.Interfaces;
using BusPass.Service.Interfaces;
using Hangfire.Console;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Scheduler.Jobs
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BusPass.Scheduler.Interfaces.IBusInitialJob" />
    public class BusInitialJob : IBusInitialJob
    {
        private readonly IBusRouteService _busRouteService;

        private readonly ILogger<BusInitialJob> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusInitialJob"/> class.
        /// </summary>
        public BusInitialJob(IBusRouteService busRouteService, ILogger<BusInitialJob> logger)
        {
            _busRouteService = busRouteService;
            _logger = logger;
        }

        /// <summary>
        /// Datas the initial create job.
        /// </summary>
        /// <param name="context">The context.</param>
        [DisplayName("排程工作 資料表初始建立資料")]
        public async Task DataInitialCreateJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now} Start Run DataInitialCreate Job");
            try
            {
                var res = false;
                foreach (var city in Enum.GetNames(typeof(CityCode)))
                {
                    res = await _busRouteService.AddBusRouteAsync(city);

                    //res = await _busRouteService.AddBusOperator(city);

                    context.WriteLine($"Add Bus Operator,city:{city},resutl:{res}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.WriteLine($"{DateTime.Now} job failed");
            }

            context.WriteLine($"{DateTime.Now} End Run DataInitialCreate Job");
        }
    }
}