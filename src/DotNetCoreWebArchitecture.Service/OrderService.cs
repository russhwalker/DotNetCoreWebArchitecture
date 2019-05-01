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


    }
}