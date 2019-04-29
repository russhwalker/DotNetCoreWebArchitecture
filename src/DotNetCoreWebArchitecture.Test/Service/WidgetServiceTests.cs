using DotNetCoreWebArchitecture.Service;
using System;
using Xunit;

namespace DotNetCoreWebArchitecture.Test.Service
{
    public class WidgetServiceTests
    {
        [Fact]
        public void GetWidgetCounts()
        {
            var service = new WidgetService(null);
            var response = service.GetWidgetCounts();
            Assert.NotNull(response);
        }
    }
}
