using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebArchitecture.Web.Models;
using DotNetCoreWebArchitecture.Common.Contracts;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWidgetService widgetService;

        public HomeController(IWidgetService widgetService)
        {
            this.widgetService = widgetService;
        }

        public IActionResult Index()
        {
            var response = widgetService.GetWidgetCounts();
            var viewModel = new MainViewModel
            {
                Widget1Count = response.Widget1Count,
                Widget2Count = response.Widget2Count,
                Widget3Count = response.Widget3Count
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}