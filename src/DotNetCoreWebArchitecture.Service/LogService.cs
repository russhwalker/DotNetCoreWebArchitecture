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

        public void AddLogEntry(LogEntry logEntry)
        {
            logEntry.CreateDate = DateTime.Now;
            _ = logRepository.AddLogEntryAsync(logEntry).Result;
        }

        public void LogError(Exception exception)
        {
            var errorLog = new ErrorLog
            {
                CreateDate = DateTime.Now,
                ErrorMessage = exception.Message,
                ExceptionData = exception.ToString()
            };
            _ = logRepository.AddErrorLogEntryAsync(errorLog).Result;
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