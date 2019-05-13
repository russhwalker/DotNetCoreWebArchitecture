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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}