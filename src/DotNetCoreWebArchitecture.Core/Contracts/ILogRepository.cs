using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface ILogRepository
    {
        bool AddLogEntry(Models.ActionLog actionLog);
        bool AddErrorLogEntry(string exceptionData, DateTime date);
        Task<List<Models.ErrorLog>> GetErrorLogsAsync();
    }
}