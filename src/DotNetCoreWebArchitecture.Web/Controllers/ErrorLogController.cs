using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Web.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class ErrorLogController : BaseController
    {
        private readonly ILogService logService;

        public ErrorLogController(ILogService logService)
        {
            this.logService = logService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var response = logService.GetErrorLogs();
            return View(response.ToViewModel());
        }

        [AllowAnonymous]
        public IActionResult ThrowError()
        {
            throw new System.Exception("this is an intentional error thrown in ErrorLog/ThrowError");
        }
    }
}