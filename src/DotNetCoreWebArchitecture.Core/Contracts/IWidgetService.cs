using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface IWidgetService
    {
        GetWidgetCountsResponse GetWidgetCounts();
    }
}