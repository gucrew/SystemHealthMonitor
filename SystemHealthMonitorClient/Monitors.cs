using System;
using System.Collections.Generic;
using System.ServiceProcess;
using Microsoft.Web.Administration;
using System.Data.Sql;
using System.Data;
using System.Diagnostics;
using SystemHealthMonitorModel;

namespace SystemHealthMonitorClient
{
    public class IISServerMonitor
    {
        public static List<MonitorInformation> Run()
        {
            var list = new List<MonitorInformation>();
            var serverManager = new ServerManager();

            foreach (var site in serverManager.Sites)
            {
                list.Add(new MonitorInformation(MonitorType.IISServer, site.Name, site.State.ToString()));

                //foreach (var app in site.Applications)
                //{
                //    Console.WriteLine(app.Path);
                //}
            }

            return list;
        }
    }

    public class WindowsServiceMonitor
    {
        public static List<MonitorInformation> Run()
        {
            var list = new List<MonitorInformation>();
            var serviceController = new ServiceController();
            var services = ServiceController.GetServices();

            foreach (var service in services)
            {
                list.Add(new MonitorInformation(MonitorType.WindowsService, service.DisplayName, service.Status.ToString()));
            }

            return list;
        }
    }

    public class MSSQLMonitor
    {
        public static List<MonitorInformation> Run()
        {
            var list = new List<MonitorInformation>();
            var instance = SqlDataSourceEnumerator.Instance;
            var table = instance.GetDataSources();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    list.Add(new MonitorInformation(MonitorType.MSSQLDatabase, col.ColumnName, row[col].ToString()));
                    //Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
            }

            return list;
        }
    }

    public class ProcessMonitor
    {
        public static List<MonitorInformation> Run()
        {
            var list = new List<MonitorInformation>();
            var collection = Process.GetProcesses();

            foreach (var item in collection)
            {
                list.Add(new MonitorInformation(MonitorType.MSSQLDatabase, item.ProcessName, "Running"));
                //Console.WriteLine("Process: {0}", item.ProcessName);
            }

            return list;
        }
    }
}