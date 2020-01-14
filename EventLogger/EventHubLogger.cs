using System;
using System.Text;
using System.Threading;
using Microsoft.ServiceBus.Messaging;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace EventLogger
{
    [Target("EventHubLog")]
    public class EventHubLogger : TargetWithLayout
    {
        [RequiredParameter]
        static string eventHubName { get; set; }
        [RequiredParameter]
        static string connectionString { get; set; }

        public EventHubLogger()
        {
            connectionString = "default_connstring";
            eventHubName = "AppName";
        }

        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = this.Layout.Render(logEvent);

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
