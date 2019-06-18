using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.EventHubs;
using System.Threading.Tasks;
using EventHubTester.Config;

namespace EventHubTester.Helpers
{

    class EventHubSender
    {
        private string _messageBody;
        private int _iterations;
        private EventHubConfig _eventHubConfig;
        private EventHubClient _eventHubClient;

        public EventHubSender(Config.EventHubConfig config, string messageBody, int iterations)
        {
            this._messageBody = messageBody;
            this._iterations = iterations;
            this._eventHubConfig = config;
        }

        public async Task SendMessages()
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(_eventHubConfig.EventHubConnectionString)
            {
                EntityPath = _eventHubConfig.EventHubName
            };

            _eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub();

            await _eventHubClient.CloseAsync();
        }

        private async Task SendMessagesToEventHub()
        {
            for (var i = 0; i < _iterations; i++)
            {

                try
                {
                    var message = _messageBody + i;
                    Console.WriteLine($"Sending message: {message}");
                    await _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }
            Console.WriteLine($"{_iterations} messages sent.");
        }
    }
}
