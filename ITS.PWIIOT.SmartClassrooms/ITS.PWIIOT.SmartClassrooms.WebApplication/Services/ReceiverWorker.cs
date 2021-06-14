using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
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
        private readonly IMessage _message;
        private readonly IClassroomService _classroomService;
        public ReceiverWorker(IMessage message, IClassroomService classroomService)
        {
            _message = message;
            _classroomService = classroomService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _message.StartReceiveMessagesFromSubscriptionAsync(
          message =>
          { 
                _classroomService.SetClassroomAvailable("");
              //NOTIFICARE A TUTTI I CLIENT CHE L'AULA è LIBERA
          }, "ITS/classroom/available");
        }
    }
}