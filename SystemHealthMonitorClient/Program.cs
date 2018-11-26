﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using SystemHealthMonitorModel;
using System.Configuration;

namespace SystemHealthMonitorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient { Encoding = Encoding.UTF8 };
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            while (true)
            {
                var list = new List<MonitorInformation>();
                list.AddRange(IISServerMonitor.Run());
                list.AddRange(WindowsServiceMonitor.Run());
                list.AddRange(ProcessMonitor.Run());
                list.AddRange(MSSQLMonitor.Run());
                var report = new MonitorReport(list);
                var json = JsonConvert.SerializeObject(report);

                try
                {
                    var response = client.UploadString(ConfigurationManager.AppSettings["ReportUrl"], "post", json);
                    Console.WriteLine(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Thread.Sleep(1000 * 60 * 15);
            }
        }
    }
}