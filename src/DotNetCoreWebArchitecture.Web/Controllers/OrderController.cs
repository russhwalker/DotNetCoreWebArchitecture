using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var viewModel = new OrdersViewModel
            {
                Orders = orderService.GetOrders().Orders
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(OrdersViewModel vm)
        {
            return null;
        }

        public IActionResult Edit(int id, bool success = false)
        {
            var response = orderService.GetOrder(id);
            var viewModel = new OrderViewModel
            {
                Order = response.Order,
                OrderItems = response.OrderItems,
                OrderStatuses = response.OrderStatuses,
                Success = success
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel viewModel)
        {
            var response = orderService.SaveOrder(viewModel.Order);
            return Edit(viewModel.Order.OrderId, response);
        }
    }
}