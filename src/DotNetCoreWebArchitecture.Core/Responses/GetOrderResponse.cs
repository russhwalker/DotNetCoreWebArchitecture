﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Responses
{
    public class GetOrderResponse
    {
        public bool IsNew { get; set; }
        public Models.Order Order { get; set; }
        public List<Models.OrderItem> OrderItems { get; set; }
        public List<Models.OrderStatus> OrderStatuses { get; set; }
    }
}