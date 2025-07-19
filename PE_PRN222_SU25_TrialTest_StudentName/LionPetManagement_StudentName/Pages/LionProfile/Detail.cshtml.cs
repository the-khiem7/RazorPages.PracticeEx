using BUL;
using Microsoft.AspNetCore.Mvc;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class DetailModel : BasePageModel
    {
        private readonly ILionProfileService service;

        public DetailModel(ILionProfileService service)
        {
            this.service = service;
        }

        public BusinessObjects.LionProfile LionProfile { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var authResult = CheckPermission();
            if (authResult != null)
            {
                return authResult;
            }
            var lionprofile = service.GetById(id);
            if (lionprofile == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = lionprofile;
            }
            return Page();
        }
    }
}
