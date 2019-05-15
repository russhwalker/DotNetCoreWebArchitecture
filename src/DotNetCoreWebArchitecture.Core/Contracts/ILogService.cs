using DotNetCoreWebArchitecture.Core.Models;
using DotNetCoreWebArchitecture.Core.Requests;
using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface ILogService
    {
        void AddLogEntry(Models.LogEntry logEntry);
        void LogError(Exception exception);
        GetErrorLogsResponse GetErrorLogs();
    }
}