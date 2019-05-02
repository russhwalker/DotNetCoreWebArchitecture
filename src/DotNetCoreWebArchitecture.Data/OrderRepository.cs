using DotNetCoreWebArchitecture.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<Core.Models.Order> GetOrderAsync(int orderId)
        {
            return databaseContext.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => new Core.Models.Order
                {
                    OrderId = o.OrderId,
                    CustomerName = o.CustomerName,
                    OrderItemCount = o.OrderItems.Count
                }).SingleAsync();
        }

        public Task<List<Core.Models.Order>> GetOrdersAsync()
        {
            return databaseContext.Orders.
                Select(o => new Core.Models.Order
                {
                    OrderId = o.OrderId,
                    CustomerName = o.CustomerName,
                    OrderItemCount = o.OrderItems.Count
                }).ToListAsync();
        }

        public Task<List<Core.Models.OrderItem>> GetOrderItemsAsync(int orderId)
        {
            return databaseContext.OrderItems
                .Where(o => o.OrderId == orderId)
                .Select(o => new Core.Models.OrderItem
                {
                    OrderItemId = o.OrderItemId,
                    WidgetName = o.Widget.WidgetName,
                    UnitPrice = o.UnitPrice
                }).ToListAsync();
        }
    }
}