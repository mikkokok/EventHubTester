using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.EventHubs;
using System.Threading.Tasks;
using EventHubTester.Config;

namespace EventHubTester.Helpers
{
    class EventHubListener
    {
        private EventHubConfig _config;

        public EventHubListener(EventHubConfig config)
        {
            _config = config;
        }
    }
}
