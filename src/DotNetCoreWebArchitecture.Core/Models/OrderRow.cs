﻿
namespace DotNetCoreWebArchitecture.Core.Models
{
    public class OrderRow
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderItemCount { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
    }
}