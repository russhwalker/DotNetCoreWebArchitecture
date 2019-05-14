using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Responses
{
    public class GetErrorLogsResponse
    {
        public List<Models.ErrorLog> ErrorLogs { get; set; }
    }
}