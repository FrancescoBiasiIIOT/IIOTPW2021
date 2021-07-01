using Hangfire;
using Hangfire.SqlServer;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public IServiceScopeFactory _serviceScopeFactory { get; set; }
        public IConfiguration Configuration{ get; set; }
        public SchedulerWorker(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            Configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        { 
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var lessonService = scope.ServiceProvider.GetRequiredService<ILessonService>();
                RecurringJob.AddOrUpdate(
                    () => lessonService.SendLessonBetweenRange(DateTime.Now, DateTime.Now),
                    Cron.Minutely);

            }

        }
    }
}
