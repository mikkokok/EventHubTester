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
        public string EventHubKey;
        [XmlElement]
        public string TestMessageBase;
        [XmlElement]
        public int Iterations;
    }
}
