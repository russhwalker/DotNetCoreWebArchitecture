using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<Data.ApplicationUser> signInManager;

        public AccountController(SignInManager<Data.ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Models.LoginViewModel viewModel)
        {
            //https://github.com/aspnet/AspNetCore/blob/release/2.2/src/Security/samples/Identity.ExternalClaims/Pages/Account/Login.cshtml.cs
            var result = await signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}