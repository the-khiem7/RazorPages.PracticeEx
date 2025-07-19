using Microsoft.AspNetCore.Mvc;

namespace LionPetManagement_StudentName.Pages
{
    public class IndexModel : BasePageModel
    {
        public IActionResult OnGet()
        {
            if (!IsLoggedIn)
            {
                return RedirectToPage("/Login");
            }

            return RedirectToPage("/LionProfile/Index");
        }
    }
}
