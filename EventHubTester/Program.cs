using System;
using EventHubTester.Config;
using EventHubTester.Helpers;

namespace EventHubTester
{
    class Program
    {
        private static readonly ConfigHelper _configHelper = new ConfigHelper();
        private static EventHubConfig _loadedConfig;
        static void Main(string[] args)
        {
            _loadedConfig = _configHelper.LoadedEventHubConfig;
            if (args.Length == 0)
            {
                RunTestSeq(_loadedConfig, _loadedConfig.TestMessageBase, _loadedConfig.Iterations);
            }
            else if (args.Length == 1)
            {
                try
                {
                    
                }
                catch 
                {
                    SendHelp();
                }
                RunTestSeq(_loadedConfig, args[0], _loadedConfig.Iterations);
            }

            SendHelp();

        }

        private static void RunTestSeq(EventHubConfig config, string messageBody, int iterations)
        {
            var _eventHubListener = new EventHubListener(config);
            var _eventHubSender = new EventHubSender(config, messageBody, iterations);

        }

        private static void SendHelp()
        {

        }
    }
}
