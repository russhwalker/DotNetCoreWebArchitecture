using DotNetCoreWebArchitecture.Core.Contracts;
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
            var viewModel = new OrdersViewModel
            {
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(OrdersViewModel vm)
        {
            return null;
        }
    }
}