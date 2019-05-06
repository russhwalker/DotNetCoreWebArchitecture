using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreWebArchitecture.Web.Models
{
    public class OrderViewModel
    {
        public bool Success { get; set; }
        public bool IsNew { get; set; }
        public Core.Models.Order Order { get; set; }
        public List<Core.Models.OrderItem> OrderItems { get; set; }
        public List<Core.Models.OrderStatus> OrderStatuses { get; set; }

        public IEnumerable<SelectListItem> OrderStatusSelectListItems
        {
            get
            {
                if(OrderStatuses == null)
                {
                    return null;
                }
                return OrderStatuses.Select(s => new SelectListItem
                {
                    Value = s.OrderStatusId.ToString(),
                    Text = s.StatusName,
                    Selected = Order.OrderStatusId == s.OrderStatusId
                });
            }
        }
    }
}