using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Web.Mappings;
using DotNetCoreWebArchitecture.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            var viewModel = orderService.GetOrders().ToViewModel();
            return View(viewModel);
        }

        public IActionResult Edit(int id, bool success = false)
        {
            var response = orderService.GetOrder(id);
            var viewModel = response.ToViewModel(success);
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