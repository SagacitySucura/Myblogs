﻿using Core;
using Core.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace App.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required]
        [BindProperty]
        public string UserName { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        SignInManager<AppUser> _sm;

        public LoginModel(SignInManager<AppUser> sm)
        {
            _sm = sm;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync([FromQuery]string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _sm.PasswordSignInAsync(UserName, Password, RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            return Page();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            returnUrl = returnUrl.SanitizePath();
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("~/");
            }
        }
    }
}