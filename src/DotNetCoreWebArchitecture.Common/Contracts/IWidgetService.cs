using DotNetCoreWebArchitecture.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Common.Contracts
{
    public interface IWidgetService
    {
        GetWidgetCountsResponse GetWidgetCounts();
    }
}