using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemHealthMonitorServer
{
    public enum MonitorType
    {
        IISServer = 1,
        WindowsService = 2,
        MSSQLDatabase = 3,
        WindowsProcess = 4
    }
}
