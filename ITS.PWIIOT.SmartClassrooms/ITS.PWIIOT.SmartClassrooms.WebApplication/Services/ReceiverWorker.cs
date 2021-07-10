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
        public IMessage Message { get; set; }
        public IEmailService EmailService { get; set; }
        public ReceiverWorker(IServiceScopeFactory serviceScopeFactory, IEmailService emailService, IMessage message)
        {
            _serviceScopeFactory = serviceScopeFactory;
            EmailService = emailService;
            Message = message;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
                await Message.StartReceiveMessagesFromSubscriptionAsync(
                message =>
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var microcontroller = scope.ServiceProvider.GetRequiredService<IMicrocontrollerService>();
                        var classroomService = scope.ServiceProvider.GetRequiredService<IClassroomService>();
                        if (message.Operation == Domain.OperationMessage.AdministratorRequest)
                        {
                            var classroom = microcontroller.GetMicrocontrollerById(message.PicId).ClassroomId;
                            EmailService.SendEmail(new Domain.EmailMessage { Classroom = classroom });
                        }
                    }
                }, "email");
    

        }

    }
} 