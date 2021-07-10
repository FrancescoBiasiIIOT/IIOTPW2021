using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.SchedulerWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public IServiceScopeFactory _serviceScopeFactory { get; set; }
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var now = DateTime.Now;
                    var date = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
                    var lessonService = scope.ServiceProvider.GetRequiredService<ILessonService>();
                    await lessonService.SendLessonBetweenRange(DateTime.Now);
                    await Task.Delay(60000);
                }
            }
        }
    }
}
