using BUL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LionPetManagement_StudentName.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPostAsync()
        {
            var user = _accountService.Login(Email, Password);
            if (user == null)
            {
                ErrorMessage = "Invalid Email or Password!";
                return Page();
            }
            if (user.RoleId == 1)
            {
                ErrorMessage = "You do not have permission to access this page.";
                return Page();
            }

            // Store user info in session
            HttpContext.Session.SetInt32("UserId", user.AccountId);
            HttpContext.Session.SetInt32("RoleId", user.RoleId);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToPage("/LionProfile/Index");
        }
    }
}
