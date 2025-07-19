using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LionPetManagement_Services_DoanNgocTrung.Services;

namespace LionPetManagement_DoanNgocTrung.Pages.Account
{
    [AllowAnonymous]
    
    public class LoginModel : PageModel
    {
        private readonly LionAccountService _lionAccountService;

        public LoginModel() => _lionAccountService ??= new LionAccountService();

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userAccount = await _lionAccountService.GetUserAccount(Email, Password);

            if (userAccount != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role, userAccount.RoleId.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                Response.Cookies.Append("UserName", userAccount.UserName);

                return RedirectToPage("/LionProfiles/Index");
                //return RedirectToPage("/Index");
            }
            else
            {
                TempData["Message"] = "Invalid Email or Password!";
            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Page();
        }
    }
}
