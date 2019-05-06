using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Models;
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
                    OrderItemCount = o.OrderItems.Count,
                    OrderStatusId = o.OrderStatusId,
                    OrderStatusName = o.OrderStatus.StatusName
                }).SingleOrDefaultAsync();
        }

        public Task<List<Core.Models.Order>> GetOrdersAsync()
        {
            return databaseContext.Orders.
                Select(o => new Core.Models.Order
                {
                    OrderId = o.OrderId,
                    CustomerName = o.CustomerName,
                    OrderItemCount = o.OrderItems.Count,
                    OrderStatusId = o.OrderStatusId,
                    OrderStatusName = o.OrderStatus.StatusName
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

        public Task<List<Core.Models.OrderStatus>> GetOrderStatusesAsync()
        {
            return databaseContext.OrderStatuses
                .Select(o => new Core.Models.OrderStatus
                {
                    OrderStatusId = o.OrderStatusId,
                    StatusName = o.StatusName
                }).ToListAsync();
        }

        public Task<int> SaveOrderAsync(Core.Models.Order order)
        {
            //TODO mapping...Automapper?
            var entity = databaseContext.Orders.Single(o => o.OrderId == order.OrderId);
            entity.OrderStatusId = order.OrderStatusId;
            entity.CustomerName = order.CustomerName;
            databaseContext.Entry(entity).State = EntityState.Modified;
            return databaseContext.SaveChangesAsync();
        }
    }
}