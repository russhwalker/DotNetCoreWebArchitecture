using DotNetCoreWebArchitecture.Core;
using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IWidgetRepository widgetRepository;

        public OrderService(IOrderRepository orderRepository,
            IWidgetRepository widgetRepository)
        {
            this.orderRepository = orderRepository;
            this.widgetRepository = widgetRepository;
        }

        public GetOrdersResponse GetOrders()
        {
            return new GetOrdersResponse
            {
                Orders = orderRepository.GetOrdersAsync().Result
            };
        }

        public GetOrderResponse GetOrder(int orderId)
        {
            var orderTask = orderRepository.GetOrderAsync(orderId);
            var orderItemsTask = orderRepository.GetOrderItemsAsync(orderId);

            Task.WhenAll(orderTask, orderItemsTask);
            return new GetOrderResponse
            {
                Order = orderTask.Result,
                OrderItems = orderItemsTask.Result
            };
        }
    }
}