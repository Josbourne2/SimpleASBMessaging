using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SimpleASBMessaging.AZFunctions
{
    public class ReceiveAndSaveMessageToBlobStorage
    {
        private ILogger<ReceiveAndSaveMessageToBlobStorage> _log;

        public ReceiveAndSaveMessageToBlobStorage(ILogger<ReceiveAndSaveMessageToBlobStorage> log)
        {
            _log = log;
        }

        [FunctionName("ReceiveAndSaveMessageToBlobStorage")]
        public async void Run([ServiceBusTrigger("%QueueName%", Connection = "ServiceBusConnectionString")] string myQueueItem,
            [Blob("france-msgs/{rand-guid}.json", FileAccess.ReadWrite, Connection = "StorageConnectionString")] CloudBlockBlob outputBlob)
        {
            string storageUrl = Environment.GetEnvironmentVariable("StorageUrl");

            await outputBlob.UploadTextAsync(myQueueItem);
            _log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}