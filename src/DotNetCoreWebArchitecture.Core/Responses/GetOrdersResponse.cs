using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Responses
{
    public class GetOrdersResponse
    {
        public List<Models.Order> Orders { get; set; }
    }
}