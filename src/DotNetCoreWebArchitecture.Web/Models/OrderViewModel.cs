using System;
using System.Collections.Generic;

namespace DotNetCoreWebArchitecture.Web.Models
{
    public class OrderViewModel
    {
        public Core.Models.Order Order { get; set; }
        public List<Core.Models.OrderItem> OrderItems { get; set; }
    }
}