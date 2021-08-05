using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleASBMessaging.API
{
    public class AzureServiceBusOptions
    {
        //The connection string to the azure service bus endpoint, also containing the queue name
        //In many examples this is the connection string + key for the root namespace which is unwanted and dangerous because permissions could be given that are not needed.
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}