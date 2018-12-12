using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SystemHealthMonitorServer
{
    public class ReportManager
    {
        SystemHealthMonitorContext Context;

        public ReportManager(SystemHealthMonitorContext context)
        {
            Context = context;
        }

        public Report Get()
        {
            return Context.Reports.FirstOrDefault();
        }

        public void Save(MonitorReport report)
        {
            var model = new Report { MachineName = report.MachineName, Timestamp = report.Timestamp, ReportInformation = new List<ReportInformation>() };

            foreach (var item in report.MonitorInformation ?? new List<MonitorInformation>())
            {
                model.ReportInformation.Add(new ReportInformation { Name = item.Name, Type = item.Type, Status = item.Status });
            }

            Context.Reports.Add(model);
            Context.SaveChanges();
        }

        public void Delete(string machineName)
        {
            var collection = Context.Reports.Include(x => x.ReportInformation).Where(x => x.MachineName == machineName).ToList();

            foreach (var report in collection)
            {
                Context.ReportInformation.RemoveRange(report.ReportInformation.ToList());
                Context.Reports.Remove(report);
                Context.SaveChanges();
            }
        }
    }
}
