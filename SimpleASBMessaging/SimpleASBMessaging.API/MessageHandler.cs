using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASBMessaging.API
{
    public class MessageHandler : IMessageHandler
    {
        private string _connectionString;
        private string _queueName;

        private ServiceBusClient _client;
        private ServiceBusSender _sender;
        private ServiceBusReceiver _receiver;

        public MessageHandler(IOptions<AzureServiceBusOptions> config)
        {
            _connectionString = config.Value.ConnectionString;
            _queueName = config.Value.QueueName;
            _client = new ServiceBusClient(_connectionString);
            _sender = _client.CreateSender(_queueName);
            _receiver = _client.CreateReceiver(_queueName);
        }

        public async Task SendAsync(string message)
        {
            await _sender.SendMessageAsync(new ServiceBusMessage(message));
        }

        public async Task<string> ReceiveAsync()
        {
            ServiceBusReceivedMessage msg = await _receiver.ReceiveMessageAsync();
            return msg.Body.ToString();
        }
    }
}