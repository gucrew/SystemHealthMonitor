using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SystemHealthMonitorServer.Controllers
{
    public class ConfigurationController : Controller
    {
        ReportManager Manager;

        public ConfigurationController(ReportManager reportManager)
        {
            Manager = reportManager;
        }

        public IActionResult Index()
        {
            var list = Manager.RetrieveServerList();
            return View(list);
        }

        public IActionResult Applications(string id)
        {
            var list = Manager.RetrieveApplicationList(id);
            return Json(list.Select(x => new { id = x, text = x }));
        }
    }
}