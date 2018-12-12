using Microsoft.AspNetCore.Mvc;

namespace SystemHealthMonitorServer.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        ReportManager ReportManager;

        public ReportController(ReportManager reportManager)
        {
            ReportManager = reportManager;
        }

        [HttpGet]
        public Report Get()
        {
            return ReportManager.Get();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public MonitorReport Post([FromBody]MonitorReport report)
        {
            ReportManager.Save(report);
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