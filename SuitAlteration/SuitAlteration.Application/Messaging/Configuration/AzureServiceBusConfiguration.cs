using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Messaging.Configuration
{ 
    public class AzureServiceBusConfiguration
    {
        public string ConnectionString { get; set; }

        public string OrderPaidTopicName { get; set; } 
    }
}
