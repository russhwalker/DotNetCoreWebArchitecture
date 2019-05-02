using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace DotNetCoreWebArchitecture.Web.Filters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private readonly ILogService logService;

        public AuditAttribute(ILogService logService)
        {
            this.logService = logService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var baseController = (BaseController)context.Controller;

            var logRequest = new Core.Requests.AddLogRequest
            {
                ControllerName = baseController.ControllerContext.ActionDescriptor.ControllerName,
                ActionName = baseController.ControllerContext.ActionDescriptor.ActionName,
                IpAddress = baseController.ControllerContext.HttpContext.Connection.RemoteIpAddress.ToString(),
                RequestUrl = baseController.Request.Host.Value,
                UserName = baseController.User.Identity.Name
            };

            logRequest.Host = Dns.GetHostEntry(logRequest.IpAddress)?.HostName?.Split('.')?.FirstOrDefault() ?? "(not found)";
            if (context.HttpContext.Request.HasFormContentType)
            {
                logRequest.FormRequestData = JsonConvert.SerializeObject(context.HttpContext.Request.Form);
            }

            logService.AddLogEntry(logRequest);
            base.OnActionExecuting(context);
        }
    }
}