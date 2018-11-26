using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Configuration;
using System.IO;

namespace SystemHealthMonitorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.txt"), "Start");
            var client = new WebClient { Encoding = Encoding.UTF8 };
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            while (true)
            {
                try
                {
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.txt"), "Working");

                    var list = new List<MonitorInformation>();
                    list.AddRange(IISServerMonitor.Run());
                    list.AddRange(WindowsServiceMonitor.Run());
                    list.AddRange(ProcessMonitor.Run());
                    list.AddRange(MSSQLMonitor.Run());
                    var report = new MonitorReport(list);
                    var json = JsonConvert.SerializeObject(report);
                    var response = client.UploadString(ConfigurationManager.AppSettings["ReportUrl"], "post", json);

                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), response);
                }
                catch (Exception e)
                {
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), e.Message);
                }

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.txt"), "Idle");

                Thread.Sleep(1000 * 60 * 15);
            }
        }
    }
}