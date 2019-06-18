using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EventHubTester.Config
{
    public class EventHubConfig
    {
        [XmlElement]
        public string EventHubName;
        [XmlElement]
        public string EventHubConnectionString;
        [XmlElement]
        public string StorageConnectionString;
        [XmlElement]
        public string StorageContainerName;
        [XmlElement]
        public string TestMessageBase;
        [XmlElement]
        public int Iterations;
    }
}
