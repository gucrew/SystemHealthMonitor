using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using System.Data.Sql;
using System.Data;

namespace SystemHealthMonitorClient
{
    public static class IISServerMonitor
    {
        public static void Run()
        {
            var serverManager = new ServerManager();

            foreach (var site in serverManager.Sites)
            {
                Console.WriteLine("Site: {0}, State: {1}", site.Name, site.State);

                foreach (var app in site.Applications)
                {
                    Console.WriteLine(app.Path);
                }
            }
        }
    }

    public class WindowsServiceMonitor
    {
        public static void Run()
        {
            var serviceController = new ServiceController();
            var services = ServiceController.GetServices();

            foreach (ServiceController service in services)
            {
                Console.WriteLine("Service: {0}, Status: {1}",service.DisplayName, service.Status);
            }
        }
    }

    public class MSSQLMonitor
    {
        public static void Run()
        {
            var instance = SqlDataSourceEnumerator.Instance;
            var table = instance.GetDataSources();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                }
            }
        }
    }
}
