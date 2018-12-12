using System;
using System.Collections.Generic;

namespace SystemHealthMonitorServer
{
    public class MonitorReport
    {
        public MonitorReport() { }

        public MonitorReport(List<MonitorInformation> monitorInformation)
        {
            MonitorInformation = monitorInformation;
        }

        public string MachineName { get; set; }
        public DateTime Timestamp { get; set; }
        public List<MonitorInformation> MonitorInformation { get; set; }
    }

    public class MonitorInformation
    {
        public MonitorInformation() { }

        public MonitorInformation(MonitorType type, string name, string status)
        {
            Type = type;
            Name = name;
            Status = status;
            Timestamp = DateTime.UtcNow;
        }

        public MonitorType Type { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
