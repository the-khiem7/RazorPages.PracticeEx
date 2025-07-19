using BUL;
using Microsoft.AspNetCore.Mvc;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class SearchModel : BasePageModel
    {
        private readonly ILionProfileService _lionProfileService;

        public SearchModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }

        [BindProperty]
        public double? Weight { get; set; }

        [BindProperty]
        public string LionTypeName { get; set; }

        public List<BusinessObjects.LionProfile> LionProfiles { get; set; } = new List<BusinessObjects.LionProfile>();
        public bool HasSearched { get; set; }

        public IActionResult OnGet()
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            return Page();
        }

        public IActionResult OnPost()
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            HasSearched = true;
            LionProfiles = _lionProfileService.Search(Weight, LionTypeName);

            return Page();
        }
    }
}
