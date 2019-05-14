using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Models;
using DotNetCoreWebArchitecture.Core.Requests;
using DotNetCoreWebArchitecture.Core.Responses;
using System;

namespace DotNetCoreWebArchitecture.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public void AddLogEntry(AddLogRequest request)
        {
            var log = new LogEntry
            {
                UserName = request.UserName,
                Host = request.Host,
                IpAddress = request.IpAddress,
                ActionName = request.ActionName,
                ControllerName = request.ControllerName,
                RequestUrl = request.RequestUrl,
                FormRequestData = request.FormRequestData,
                CreateDate = DateTime.Now
            };
            _ = logRepository.AddLogEntryAsync(log).Result;
        }

        public void LogException(Exception exception)
        {
            _ = logRepository.AddErrorLogEntryAsync(exception.ToString(), DateTime.Now).Result;
        }

        public GetErrorLogsResponse GetErrorLogs()
        {
            return new GetErrorLogsResponse
            {
                ErrorLogs = logRepository.GetErrorLogsAsync().Result
            };
        }
    }
}