using DotNetCoreWebArchitecture.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly DatabaseContext databaseContext;

        public LogRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public bool AddLogEntry(Core.Models.ActionLog actionLog)
        {
            var logEntry = new LogEntry
            {
                UserName = actionLog.UserName,
                Host = actionLog.Host,
                IpAddress = actionLog.IpAddress,
                ActionName = actionLog.ActionName,
                ControllerName = actionLog.ControllerName,
                RequestUrl = actionLog.RequestUrl,
                FormRequestData = actionLog.FormRequestData,
                CreateDate = actionLog.CreateDate
            };
            databaseContext.LogEntries.Add(logEntry);
            return databaseContext.SaveChanges() > 0;
        }
    }
}