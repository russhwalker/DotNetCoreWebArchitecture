
namespace DotNetCoreWebArchitecture.Core.Requests
{
    public class AddLogRequest
    {
        public string UserName { get; set; }
        public string Host { get; set; }
        public string IpAddress { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string RequestUrl { get; set; }
        public string FormRequestData { get; set; }
    }
}