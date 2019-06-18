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
            switch (args.Length)
            {
                case 0:
                    RunTestSeq(_loadedConfig, _loadedConfig.TestMessageBase, _loadedConfig.Iterations);
                    break;
                case 1:
                    RunTestSeq(_loadedConfig, args[0], _loadedConfig.Iterations);
                    break;
                case 2:
                    int.TryParse(args[1], out var tempIter);
                    RunTestSeq(_loadedConfig, args[0], tempIter);
                    break;
                default:
                    SendHelp();
                    break;
            }

            Console.ReadLine();
        }

        private static void RunTestSeq(EventHubConfig config, string messageBody, int iterations)
        {
            var _eventHubListener = new EventHubListener(config);
            var _eventHubSender = new EventHubSender(config, messageBody, iterations);
            _eventHubListener.StartListening().GetAwaiter().GetResult();
            _eventHubSender.SendMessages().GetAwaiter().GetResult();
            }

        private static void SendHelp()
        {
            Console.WriteLine("Use me by providing arguments:");
            Console.WriteLine("1. Messagebase");
            Console.WriteLine("2. Number of iterations");
        }
    }
}
