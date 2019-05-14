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