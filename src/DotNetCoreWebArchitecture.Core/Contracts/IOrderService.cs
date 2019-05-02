using DotNetCoreWebArchitecture.Core.Requests;
using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface IOrderService
    {
        GetOrdersResponse GetOrders();
        GetOrderResponse GetOrder(int orderId);
        bool SaveOrder(Models.Order order);
    }
}