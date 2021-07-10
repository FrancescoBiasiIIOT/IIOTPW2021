using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Service_Bus_Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Services
{
    public class LogWorker : BackgroundService
    {

        public IServiceScopeFactory _serviceScopeFactory { get; set; }
        public IMessage Message { get; set; }
        public LogWorker(IServiceScopeFactory serviceScopeFactory, IMessage message)
        {
            _serviceScopeFactory = serviceScopeFactory;
            Message = message;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var logservice = scope.ServiceProvider.GetRequiredService<ILogService>();
                await Message.StartReceiveMessagesFromSubscriptionAsync(
                message =>
                {
                    if(message.Operation == Domain.OperationMessage.Log)
                    {
                        logservice.Insert(message.Message);
                    }
                }, "log");
            }

        }

    }
}