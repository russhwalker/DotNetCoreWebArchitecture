using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetCoreWebArchitecture.Core.Contracts;
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
        private readonly IMapper mapper;

        public LogRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public Task<int> AddLogEntryAsync(Core.Models.LogEntry logEntry)
        {
            var entity = mapper.Map<LogEntry>(logEntry);
            databaseContext.LogEntries.Add(entity);
            return databaseContext.SaveChangesAsync();
        }

        public Task<int> AddErrorLogEntryAsync(string exceptionData, DateTime date)
        {
            var logEntry = new ErrorLog
            {
                ExceptionData = exceptionData,
                CreateDate = date
            };
            databaseContext.ErrorLogEntries.Add(logEntry);
            return databaseContext.SaveChangesAsync();
        }

        public Task<List<Core.Models.ErrorLog>> GetErrorLogsAsync()
        {
            return databaseContext.ErrorLogEntries
                .OrderByDescending(l => l.CreateDate)
                .ProjectTo<Core.Models.ErrorLog>()
                .ToListAsync();
        }
    }
}