using AutoMapper.QueryableExtensions;
using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool AddErrorLogEntry(string exceptionData, DateTime date)
        {
            var logEntry = new ErrorLog
            {
                ExceptionData = exceptionData,
                CreateDate = date
            };
            databaseContext.ErrorLogEntries.Add(logEntry);
            return databaseContext.SaveChanges() > 0;
        }

        public Task<List<Core.Models.ErrorLog>> GetErrorLogsAsync()
        {
            return databaseContext.ErrorLogEntries
                .ProjectTo<Core.Models.ErrorLog>()
                .ToListAsync();
        }
    }
}