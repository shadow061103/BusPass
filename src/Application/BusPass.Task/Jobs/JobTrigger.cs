using BusPass.Task.Interfaces;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Task.Jobs
{
    public class JobTrigger : IJobTrigger
    {
        public void OnStart()
        {
            RecurringJob.AddOrUpdate<IBusInitialJob>
                 (
                 x => x.DataInitialCreateJob(null),
                 "0 8 * * *",
                 TimeZoneInfo.Local
                 );
        }
    }
}