using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface ILogRepository
    {
        Task<int> AddLogEntryAsync(Core.Models.LogEntry logEntry);
        Task<int> AddErrorLogEntryAsync(Models.ErrorLog errorLog);
        Task<List<Models.ErrorLog>> GetErrorLogsAsync();
    }
}