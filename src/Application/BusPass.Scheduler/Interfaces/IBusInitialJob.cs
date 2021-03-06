using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Scheduler.Interfaces
{
    public interface IBusInitialJob
    {
        System.Threading.Tasks.Task DataInitialCreateJob(PerformContext context);
    }
}