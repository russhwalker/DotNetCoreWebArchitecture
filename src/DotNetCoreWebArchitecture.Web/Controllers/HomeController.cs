using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebArchitecture.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ThrowError()
        {
            throw new System.Exception("this is an intentional error thrown in Home/ThrowError");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}