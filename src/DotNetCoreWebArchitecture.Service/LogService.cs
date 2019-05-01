using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Requests;

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
            //var logEntry = new LogEntry
            logRepository.AddLogEntry();
        }
    }
}