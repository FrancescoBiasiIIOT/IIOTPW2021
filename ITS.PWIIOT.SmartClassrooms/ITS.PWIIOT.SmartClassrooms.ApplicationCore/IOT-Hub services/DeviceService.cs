using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.IOT_Hub_services
{
    public class DeviceService : IDeviceService
    {
        private readonly IConfiguration _configuration;
        private readonly string _iotHubConnectionString;
        private DeviceClient _deviceClient; //device client non può essere settato nel costruttore perchè dipende dal dispositivo che chiama
        public DeviceService(IConfiguration configuration)
        {
            _iotHubConnectionString = _configuration.GetConnectionString("IotHub");
        }
        public async Task<string> ReceiveMessageFromHub(string deviceId)
        {
            var deviceConnectionString = "HostName=ProjectWorkHub.azure-devices.net;DeviceId=TestDato;SharedAccessKey=NbF6zU6Vbjf9G8PRuvp8DwQRO8gFTh27L19KuHrW7/k=";
            var deviceClient = DeviceClient.CreateFromConnectionString(
                   deviceConnectionString,
                   Microsoft.Azure.Devices.Client.TransportType.Mqtt);
            var receivedMessage = await deviceClient.ReceiveAsync(new TimeSpan(1));
            if (receivedMessage != null)
            {
                var message = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                await deviceClient.CompleteAsync(receivedMessage);
                return message;
            }
            else return null;
        }
    }
}
