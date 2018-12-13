using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<ReportInformation> ReportInformation { get; set; }
    }

    public class ReportInformation
    {
        public int ReportInformationId { get; set; }
        public MonitorType Type { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        [Required]
        public virtual Report Report { get; set; }
    }
}
