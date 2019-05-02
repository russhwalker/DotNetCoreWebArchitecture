using DotNetCoreWebArchitecture.Core.Requests;
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
        Task<List<Models.Order>> GetOrdersAsync();
        Task<List<Models.OrderItem>> GetOrderItemsAsync(int orderId);
    }
}