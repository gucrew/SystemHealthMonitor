using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SystemHealthMonitorModel;

namespace SystemHealthMonitorServer.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public MonitorReport Post([FromBody]MonitorReport report)
        {
            return report;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
