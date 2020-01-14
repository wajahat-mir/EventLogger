Event Logger

NLog extension to send logging to event hub. The idea is store this into an Azure Data Lake Storage via the Event Hub.

Input required:
EventHub connection string and AppName
An instance of the setup in your config will be as follows 

<nlog> 
  <extensions> 
    <add assembly="EventLogger"/> 
  </extensions> 
  <targets> 
    <target name="EHLog" type="EventHubLog" connectionString="..." eventHubName="..."/> 
  <rules> 
    <logger name="*" minLevel="Info" appendTo="EHLog"/> 
  </rules> 
</nlog>