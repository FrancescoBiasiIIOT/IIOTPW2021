using Azure.Messaging.ServiceBus;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Service_Bus_Services
{
    public class ServiceBusService : IMessage
    {
        private readonly string _connectionString;
        private readonly string _topicName;
        private ServiceBusProcessor processor;
        private string _subsciptionName;
        private readonly IConfiguration configuration;
        private readonly ServiceBusClient client;
        public ServiceBusService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("ServiceBus");
            _topicName = configuration.GetConnectionString("TopicName");
            client = new ServiceBusClient(_connectionString);
        }
        public async Task StartReceiveMessagesFromSubscriptionAsync(Action<EmailMessage> processMessageFunc, string subscriptionName)
        {
            try
            {
                _subsciptionName = subscriptionName;
                processor = client.CreateProcessor(_topicName, _subsciptionName, new ServiceBusProcessorOptions());
                processor.ProcessMessageAsync += async args =>
                {
                    string body = args.Message.Body.ToString();
                    var message = JsonSerializer.Deserialize<EmailMessage>(body);
                    processMessageFunc.Invoke(message);
                    await args.CompleteMessageAsync(args.Message);
                };
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }


        public async Task StopReceiveMessagesFromSubscriptionAsync()
        {
            if (processor != null)
                await processor.StopProcessingAsync();
        }
    }
}
