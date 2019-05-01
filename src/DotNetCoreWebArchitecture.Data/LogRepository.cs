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

        public bool AddLogEntry()
        {
            //databaseContext.LogEntries.Add(logEntry);
            //return databaseContext.SaveChanges() > 0;
            return false;
        }
    }
}