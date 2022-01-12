using BusPass.Task.Interfaces;
using Hangfire.Console;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Task.Jobs
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="BusPass.Task.Interfaces.IBusInitialJob" />
    public class BusInitialJob : IBusInitialJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusInitialJob"/> class.
        /// </summary>
        public BusInitialJob()
        {
        }

        /// <summary>
        /// Datas the initial create job.
        /// </summary>
        /// <param name="context">The context.</param>
        [DisplayName("排程工作 資料表初始建立資料")]
        public async System.Threading.Tasks.Task DataInitialCreateJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now} Start Run DataInitialCreate Job");

            context.WriteLine($"{DateTime.Now} End Run DataInitialCreate Job");
        }
    }
}