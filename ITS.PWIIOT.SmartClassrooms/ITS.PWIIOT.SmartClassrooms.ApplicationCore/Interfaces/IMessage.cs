using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces
{
    public interface IMessage
    {
        Task StartReceiveMessagesFromSubscriptionAsync(Action<MessageFromDevice> action, string subscriptionName);
        Task StopReceiveMessagesFromSubscriptionAsync();
    }
}
