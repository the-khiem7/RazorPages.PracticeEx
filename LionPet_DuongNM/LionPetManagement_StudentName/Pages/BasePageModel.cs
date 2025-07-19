using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LionPetManagement_StudentName.Pages
{
    public class BasePageModel : PageModel
    {
        // biến kiểm tra đăng nhập chưa
        protected bool IsLoggedIn => HttpContext.Session.GetInt32("UserId") != null;
        public bool IsManager => HttpContext.Session.GetInt32("RoleId") == 2; // Manager role
        protected bool IsStaff => HttpContext.Session.GetInt32("RoleId") == 3; // Staff role

        public string ErrorMessage { get; set; }

        protected IActionResult CheckPermission(bool requireManager = false)
        {
            if (!IsLoggedIn)
            {
                return RedirectToPage("/Login");
            }

            if (requireManager && !IsManager)
            {
                ErrorMessage = "You have no permission to access this function!";
                return RedirectToPage("/LionProfile/Index", new { error = ErrorMessage });
            }

            return null;
        }

        // Add logout functionality
        protected IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
