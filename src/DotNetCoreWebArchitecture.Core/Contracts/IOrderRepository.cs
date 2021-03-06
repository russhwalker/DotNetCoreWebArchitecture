﻿using DotNetCoreWebArchitecture.Core.Requests;
using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface IOrderRepository
    {
        Task<Models.Order> GetOrderAsync(int orderId);
        Task<List<Models.OrderRow>> GetOrderRowsAsync();
        Task<List<Models.OrderItem>> GetOrderItemsAsync(int orderId);
        Task<List<Models.OrderStatus>> GetOrderStatusesAsync();
        Task<int> SaveOrderAsync(Models.Order order);
    }
}