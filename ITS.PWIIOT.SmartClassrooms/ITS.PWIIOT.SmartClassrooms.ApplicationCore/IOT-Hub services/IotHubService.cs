using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.IOT_Hub_services
{
    public class IotHubService : IIotHubService
    {
        private readonly string _iotHubConnectionString;
        private readonly IConfiguration _configuration;
        private ServiceClient serviceClient;
        public IotHubService(IConfiguration configuration)
        {
            _configuration = configuration;
            _iotHubConnectionString = _configuration.GetConnectionString("IotHub");
            serviceClient = ServiceClient.CreateFromConnectionString(_iotHubConnectionString);
        }
        public async void SendMessageToDevice(string message, string deviceId)
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes(message));
            await serviceClient.SendAsync(deviceId, commandMessage);
        }
    }
}