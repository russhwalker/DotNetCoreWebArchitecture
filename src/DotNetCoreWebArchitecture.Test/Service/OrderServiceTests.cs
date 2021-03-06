using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCoreWebArchitecture.Test.Service
{
    public class OrderServiceTests
    {
        [Fact]
        public void GetOrders()
        {
            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(r => r.GetOrderRowsAsync())
                .ReturnsAsync(new List<Core.Models.OrderRow>
                {
                    new Core.Models.OrderRow(),
                    new Core.Models.OrderRow()
                });
            var service = new OrderService(orderRepo.Object, null);
            var response = service.GetOrders();
            Assert.NotNull(response);
            Assert.Equal(2, response.OrderRows.Count);
            orderRepo.Verify(r => r.GetOrderRowsAsync(), Times.Once);
        }

        [Fact]
        public void GetOrder_Existing()
        {
            const int orderId = 7;
            var orderRepo = new Mock<IOrderRepository>();
            orderRepo.Setup(r => r.GetOrderStatusesAsync())
                .ReturnsAsync(new List<Core.Models.OrderStatus>
                {
                    new Core.Models.OrderStatus(),
                    new Core.Models.OrderStatus()
                });
            orderRepo.Setup(r => r.GetOrderAsync(orderId))
                .ReturnsAsync(new Core.Models.Order());
            orderRepo.Setup(r => r.GetOrderItemsAsync(orderId))
                .ReturnsAsync(new List<Core.Models.OrderItem>
                {
                    new Core.Models.OrderItem()
                });

            var service = new OrderService(orderRepo.Object, null);
            var response = service.GetOrder(orderId);
            Assert.NotNull(response);
            Assert.NotNull(response.Order);
            Assert.Single(response.OrderItems);
            Assert.Equal(2, response.OrderStatuses.Count);

            orderRepo.Verify(r => r.GetOrderStatusesAsync(), Times.Once);
            orderRepo.Verify(r => r.GetOrderAsync(orderId), Times.Once);
            orderRepo.Verify(r => r.GetOrderItemsAsync(orderId), Times.Once);
        }
    }
}