using DotNetCoreWebArchitecture.Core.Responses;
using DotNetCoreWebArchitecture.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Web.Mappings
{
    public static class ResponseToViewModel
    {
        public static OrdersViewModel ToViewModel(this GetOrdersResponse response)
        {
            return new OrdersViewModel
            {
                OrderRows = response.OrderRows
            };
        }

        public static OrderViewModel ToViewModel(this GetOrderResponse response, bool success)
        {
            return new OrderViewModel
            {
                IsNew = response.IsNew,
                Order = response.Order,
                OrderItems = response.OrderItems,
                OrderStatuses = response.OrderStatuses,
                Success = success
            };
        }
    }
}