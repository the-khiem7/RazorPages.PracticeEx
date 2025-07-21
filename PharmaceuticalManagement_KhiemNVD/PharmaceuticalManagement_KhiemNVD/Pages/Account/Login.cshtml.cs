using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmaceuticalManagement_Service.Services;

namespace PharmaceuticalManagement_KhiemNVD.Pages.Account
{
    [AllowAnonymous]
    
    public class LoginModel : PageModel
    {
        private readonly StoreAccountService _storeAccountService;

        public LoginModel() => _storeAccountService ??= new StoreAccountService();

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userAccount = await _storeAccountService.GetAccount(Email, Password);

            if (userAccount != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Role, userAccount.Role.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                Response.Cookies.Append("UserName", userAccount.EmailAddress);

                return RedirectToPage("/MedicineInfo/Index");
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
