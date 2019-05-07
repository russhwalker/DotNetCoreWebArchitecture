using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public OrderRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public Task<Core.Models.Order> GetOrderAsync(int orderId)
        {
            return databaseContext.Orders
                .Where(o => o.OrderId == orderId)
                .ProjectTo<Core.Models.Order>()
                .SingleOrDefaultAsync();
        }

        public Task<List<Core.Models.OrderRow>> GetOrderRowsAsync()
        {
            return databaseContext.Orders.
                Select(o => new Core.Models.OrderRow
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
                .ProjectTo<Core.Models.OrderStatus>()
                .ToListAsync();
        }

        public Task<int> SaveOrderAsync(Core.Models.Order order)
        {
            var entity = mapper.Map<Order>(order);
            databaseContext.Entry(entity).State = EntityState.Modified;
            return databaseContext.SaveChangesAsync();
        }
    }
}