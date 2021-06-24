using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
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

        public SchedulerWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ILessonService>();
                await context.AddNewLesson(new DTO.LessonInfo());

                // now do your work
            }
        }
    }
}
