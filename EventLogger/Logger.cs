using System;
using System.Text;
using System.Threading;
using Microsoft.ServiceBus.Messaging;

namespace EventLogger
{
    public class Logger
    {
        static string eventHubName = "uncharted";
        static string connectionString = "namespace connection string";

        public Logger(string appName)
        {
            eventHubName = appName;
        }

        public static void Debug(string logMessage)
        {
            SendingMessage(logMessage);
        }

        public static void Error(string logMessage)
        {
            SendingMessage(logMessage);
        }

        static void SendingMessage(string message)
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            while (true)
            {
                try
                {
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {

                }
            }
        }
    }
}
