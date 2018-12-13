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

            while (true)
            {
                try
                {
                    using (var client = new WebClient { Encoding = Encoding.UTF8 })
                    {
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.txt"), "Working");
                        var list = new List<MonitorInformation>();
                        list.AddRange(IISServerMonitor.Run());
                        list.AddRange(WindowsServiceMonitor.Run());
                        list.AddRange(ProcessMonitor.Run());
                        list.AddRange(MSSQLMonitor.Run());
                        var report = new MonitorReport(list);
                        var json = JsonConvert.SerializeObject(report);
                        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), json);
                        client.UploadString(ConfigurationManager.AppSettings["ReportUrl"], "post", json);
                    }
                }
                catch (Exception e)
                {
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.txt"), e.Message);
                }

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.txt"), "Idle");
                Console.WriteLine("DONE");

                Thread.Sleep(1000 * 60 * 15);
            }
        }
    }
}