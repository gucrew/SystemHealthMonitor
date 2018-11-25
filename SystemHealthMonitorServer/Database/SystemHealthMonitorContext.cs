using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemHealthMonitorModel;

namespace SystemHealthMonitorServer
{
    public class SystemHealthMonitorContext : DbContext
    {
        public SystemHealthMonitorContext(DbContextOptions<SystemHealthMonitorContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportInformation> ReportInformation { get; set; }
    }

    public class Report
    {
        public int ReportId { get; set; }
        public string MachineName { get; set; }
        public DateTime Timestamp { get; set; }

        public ICollection<ReportInformation> ReportInformation { get; set; }
    }

    public class ReportInformation
    {
        public int ReportInformationId { get; set; }
        public MonitorType Type { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Report Report { get; set; }
    }
}
