using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Responses
{
    public class GetOrdersResponse
    {
        public List<Models.OrderRow> OrderRows { get; set; }
    }
}