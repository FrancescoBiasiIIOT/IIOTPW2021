using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.TestWorker
{
    public class Worker : BackgroundService
    {
        private readonly IMessage _message;
        public Worker(IMessage message)
        {
            _message = message;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _message.StartReceiveMessagesFromSubscriptionAsync(
          message =>
          {
              Console.WriteLine(message);
              //NOTIFICARE A TUTTI I CLIENT CHE L'AULA è LIBERA
          }, "notify");
        }
    }
}

