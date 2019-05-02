using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreWebArchitecture.Web.Models
{
    public class OrderViewModel
    {
        public bool Success { get; set; }
        public Core.Models.Order Order { get; set; }
        public List<Core.Models.OrderItem> OrderItems { get; set; }
        public List<Core.Models.OrderStatus> OrderStatuses { get; set; }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OrderStatusSelectListItems
        {
            get
            {
                return OrderStatuses.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = s.OrderStatusId.ToString(),
                    Text = s.StatusName,
                    Selected = Order.OrderStatusId == s.OrderStatusId
                });
            }
        }
    }
}