﻿using System;
using System.Collections.Generic;

namespace SystemHealthMonitorClient
{
    public class MonitorReport
    {
        public MonitorReport() { }

        public MonitorReport(List<MonitorInformation> monitorInformation)
        {
            MonitorInformation = monitorInformation;
        }

        public string MachineName { get { return Environment.MachineName; } }
        public DateTime Timestamp { get { return DateTime.UtcNow; } }
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
