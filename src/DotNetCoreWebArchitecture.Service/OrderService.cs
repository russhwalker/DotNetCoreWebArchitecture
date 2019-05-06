using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Models;
using DotNetCoreWebArchitecture.Core.Responses;
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
            var response = new GetOrderResponse
            {
                IsNew = orderId == 0
            };
            var orderStatusesTask = orderRepository.GetOrderStatusesAsync();
            var orderTask = orderRepository.GetOrderAsync(orderId);
            var orderItemsTask = orderRepository.GetOrderItemsAsync(orderId);

            Task.WhenAll(orderStatusesTask, orderTask, orderItemsTask);

            response.Order = orderTask.Result ?? new Order();
            response.OrderStatuses = orderStatusesTask.Result;
            response.OrderItems = orderItemsTask.Result;
            return response;
        }

        public bool SaveOrder(Order order)
        {
            var orderTask = orderRepository.SaveOrderAsync(order);
            Task.WhenAll(orderTask);
            return orderTask.Result > 0;
        }
    }
}