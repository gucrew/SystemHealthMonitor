using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHealthMonitorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MonitorInformation>();

            list.AddRange(IISServerMonitor.Run());
            list.AddRange(WindowsServiceMonitor.Run());
            list.AddRange(ProcessMonitor.Run());
            list.AddRange(MSSQLMonitor.Run());

            var report = new MonitorReport
            {
                MonitorInformation = list
            };
        }
    }
}