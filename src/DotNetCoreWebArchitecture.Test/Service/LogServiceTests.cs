using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DotNetCoreWebArchitecture.Test.Service
{
    public class LogServiceTests
    {
        [Fact]
        public void AddLogEntry()
        {
            var logEntry = new Core.Models.LogEntry();
            var logRepo = new Mock<ILogRepository>();
            logRepo.Setup(r => r.AddLogEntryAsync(It.IsAny<Core.Models.LogEntry>()))
                .ReturnsAsync(0);

            var service = new LogService(logRepo.Object);
            service.AddLogEntry(logEntry);

            logRepo.Verify(r => r.AddLogEntryAsync(It.IsAny<Core.Models.LogEntry>()), Times.Once);
        }

        [Fact]
        public void LogError()
        {
            var logRepo = new Mock<ILogRepository>();
            logRepo.Setup(r => r.AddErrorLogEntryAsync(It.IsAny<Core.Models.ErrorLog>()))
                .ReturnsAsync(0);

            var service = new LogService(logRepo.Object);
            service.LogError(new System.Exception());

            logRepo.Verify(r => r.AddErrorLogEntryAsync(It.IsAny<Core.Models.ErrorLog>()), Times.Once);
        }

        [Fact]
        public void GetErrorLogs()
        {
            var logRepo = new Mock<ILogRepository>();
            logRepo.Setup(r => r.GetErrorLogsAsync())
                .ReturnsAsync(new List<Core.Models.ErrorLog>
                {
                    new Core.Models.ErrorLog(),
                    new Core.Models.ErrorLog(),
                    new Core.Models.ErrorLog()
                });

            var service = new LogService(logRepo.Object);
            var response = service.GetErrorLogs();

            Assert.NotNull(response);
            Assert.NotNull(response.ErrorLogs);
            Assert.Equal(3, response.ErrorLogs.Count);
            logRepo.Verify(r => r.GetErrorLogsAsync(), Times.Once);
        }
    }
}