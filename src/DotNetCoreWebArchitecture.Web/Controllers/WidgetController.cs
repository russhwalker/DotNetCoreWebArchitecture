using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebArchitecture.Web.Models;
using DotNetCoreWebArchitecture.Core.Contracts;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IWidgetService widgetService;

        public WidgetController(IWidgetService widgetService)
        {
            this.widgetService = widgetService;
        }

        public IActionResult Index()
        {
            var response = widgetService.GetWidgetCounts();
            var viewModel = new WidgetViewModel
            {
                Widget1Count = response.Widget1Count,
                Widget2Count = response.Widget2Count,
                Widget3Count = response.Widget3Count
            };
            return View(viewModel);
        }
    }
}