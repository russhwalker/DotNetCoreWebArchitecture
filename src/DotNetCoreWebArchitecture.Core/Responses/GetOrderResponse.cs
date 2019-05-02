using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Responses
{
    public class GetOrderResponse
    {
        public Models.Order Order { get; set; }
        public List<Models.OrderItem> OrderItems { get; set; }
    }
}