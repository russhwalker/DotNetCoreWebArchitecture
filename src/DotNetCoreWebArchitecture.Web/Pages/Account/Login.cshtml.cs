using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetCoreWebArchitecture.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Data.ApplicationUser> signInManager;

        public LoginModel(SignInManager<Data.ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //var result = signInManager.PasswordSignInAsync(Email, Password, false, false).Result;
        }
    }
}