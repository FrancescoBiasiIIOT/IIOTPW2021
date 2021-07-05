using Hangfire;
using Hangfire.SqlServer;
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
        public IServiceScopeFactory _serviceScopeFactory { get; set; }

        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            GlobalConfiguration.Configuration
    .UseSqlServerStorage("Data Source=DESKTOP-LP5FFTL;Initial Catalog=SMARTCLASSROOMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", new SqlServerStorageOptions());
            using (var server = new BackgroundJobServer())
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {

                    var lesson = scope.ServiceProvider.GetRequiredService<ILessonService>();
                    RecurringJob.AddOrUpdate(() => lesson.SendLessonBetweenRange(DateTime.Now, DateTime.Now).ConfigureAwait(false), Cron.Minutely);
                }
            }
        }
    }
}
