﻿
namespace DotNetCoreWebArchitecture.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderItemCount { get; set; }
    }
}