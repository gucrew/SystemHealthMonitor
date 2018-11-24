using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace SystemHealthMonitorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverManager = new ServerManager();

            foreach (var site in serverManager.Sites)
            {
                Console.WriteLine("Site: {0} - {1}", site.Name, site.State);

                foreach (var app in site.Applications)
                {
                    Console.WriteLine(app.Path);
                }
            }
        }
    }
}