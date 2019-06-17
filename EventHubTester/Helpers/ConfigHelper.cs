using EventHubTester.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EventHubTester.Helpers
{
    class ConfigHelper
    {
        private const string Config = "Config\app.config";
        private EventHubConfig _eventHubConfig;
        
        private void LoadConfig()
        {
            if (!File.Exists(Config))
                return;

            using (var fileStream = new FileStream(Config, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(EventHubConfig));
                _eventHubConfig = (EventHubConfig)xmlSerializer.Deserialize(fileStream);
            }
        }

        public EventHubConfig LoadedEventHubConfig
        {
            get
            {
                if (null != _eventHubConfig) return _eventHubConfig;

                LoadConfig();
                return _eventHubConfig;

            }
        }
    }
}
