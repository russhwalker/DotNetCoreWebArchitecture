using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class WidgetController : BaseController
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

        [HttpPost]
        public IActionResult Index(WidgetViewModel vm)
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