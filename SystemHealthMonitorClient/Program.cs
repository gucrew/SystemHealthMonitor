﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using SystemHealthMonitorModel;

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
            var report = new MonitorReport(list);

            using (var client = new WebClient { Encoding = Encoding.UTF8 })
            {
                var json = JsonConvert.SerializeObject(report);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var response = client.UploadString("http://localhost:29957/api/report", "post", json);
                Console.WriteLine(response);
            }

            Thread.Sleep(1000 * 30);
        }
    }
}