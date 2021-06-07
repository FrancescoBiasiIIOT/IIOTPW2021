using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Services
{
    public class ReceiverWorker : BackgroundService
    {
        //Worker per ricevere i messaggi dal dispositivo 
        public ReceiverWorker()
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }
    }
}