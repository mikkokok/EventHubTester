using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System.Threading.Tasks;
using EventHubTester.Config;
using EventHubTester.Processors;

namespace EventHubTester.Helpers
{
    class EventHubListener
    {
        private readonly EventProcessorHost _eventProcessorHost;

        public EventHubListener(EventHubConfig config)
        {
            var eventHubConfig = config;
            _eventProcessorHost = new EventProcessorHost(eventHubConfig.EventHubName, PartitionReceiver.DefaultConsumerGroupName, eventHubConfig.EventHubConnectionString, eventHubConfig.StorageConnectionString, eventHubConfig.StorageContainerName);
        }

        public async Task StartListening()
        {
            await _eventProcessorHost.RegisterEventProcessorAsync<EventHubMessageProcessor>();
        }

        public async Task StopListening()
        {
            await _eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
