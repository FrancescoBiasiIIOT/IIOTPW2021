using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Services
{
    public class SchedulerWorker : BackgroundService
    {
        //worker per schedulare il calendario
        public SchedulerWorker()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


        }
    }
}
