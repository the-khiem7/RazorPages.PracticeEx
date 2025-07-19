using BUL;
using Microsoft.AspNetCore.Mvc;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class IndexModel : BasePageModel
    {
        private readonly ILionProfileService _lionProfileService;
        private const int PageSize = 3;

        public IndexModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }

        public List<BusinessObjects.LionProfile> LionProfiles { get; set; } = new List<BusinessObjects.LionProfile>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IActionResult OnGet(int pageNumber = 1, string error = null)
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            if (!string.IsNullOrEmpty(error))
            {
                ErrorMessage = error;
            }

            CurrentPage = pageNumber;
            var allProfiles = _lionProfileService.GetAll();

            TotalPages = (int)Math.Ceiling(allProfiles.Count / (double)PageSize);
            LionProfiles = allProfiles
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return Page();
        }

        // Add logout handler
        public IActionResult OnPostLogout()
        {
            return Logout();
        }
    }
}
