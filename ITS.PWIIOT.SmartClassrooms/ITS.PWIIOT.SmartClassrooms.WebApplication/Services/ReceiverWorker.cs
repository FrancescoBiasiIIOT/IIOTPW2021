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
    public class ReceiverWorker : BackgroundService
    {

        public IServiceScopeFactory _serviceScopeFactory { get; set; }
        public IEmailService EmailService { get; set; }
        public ReceiverWorker(IServiceScopeFactory serviceScopeFactory, IEmailService emailService)
        {
            _serviceScopeFactory = serviceScopeFactory;
            EmailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var message = scope.ServiceProvider.GetRequiredService<IMessage>();
                EmailService.SendEmail(new Domain.EmailMessage());
                await message.StartReceiveMessagesFromSubscriptionAsync(
                message =>
                {
                    
                    EmailService.SendEmail(message);
                }, "receiver");
            }
        }

    }
}