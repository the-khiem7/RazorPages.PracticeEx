using BUL;
using LionPetManagement_StudentName.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class CreateModel : BasePageModel
    {
        private readonly ILionProfileService lionProfileService;
        private readonly ILionTypeService lionTypeService;
        private readonly IHubContext<SignalHub> hubContext;

        public CreateModel(ILionProfileService lionProfileService, ILionTypeService lionTypeService, IHubContext<SignalHub> hubContext)
        {
            this.lionTypeService = lionTypeService;
            this.lionProfileService = lionProfileService;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public LionProfileInput Input { get; set; } = new();

        public SelectList LionTypes { get; set; } = null!;

        public class LionProfileInput
        {
            [Required(ErrorMessage = "Lion Name is required")]
            [MinLength(4, ErrorMessage = "Lion Name must be at least 4 characters")]
            public string LionName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Weight is required")]
            [Range(30.1, double.MaxValue, ErrorMessage = "Weight must be greater than 30")]
            public double Weight { get; set; }

            [Required(ErrorMessage = "Lion Type is required")]
            public int LionTypeId { get; set; }

            public string Characteristics { get; set; } = string.Empty;
            public string Warning { get; set; } = string.Empty;
        }

        public IActionResult OnGet()
        {
            // kiem tra user co quyen create hay ko
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            LoadLionTypes();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            // Custom validation for LionName
            if (!string.IsNullOrEmpty(Input.LionName))
            {
                // Check for special characters
                if (Regex.IsMatch(Input.LionName, @"[#@&()]"))
                {
                    ModelState.AddModelError("Input.LionName", "Lion Name cannot contain special characters (#, @, &, (, ))");
                }

                // Check if each word starts with capital letter
                var words = Input.LionName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!char.IsUpper(word[0]))
                    {
                        ModelState.AddModelError("Input.LionName", "Each word in Lion Name must start with a capital letter");
                        break;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                LoadLionTypes();
                return Page();
            }

            var lionProfile = new BusinessObjects.LionProfile
            {
                LionName = Input.LionName,
                Weight = Input.Weight,
                LionTypeId = Input.LionTypeId,
                Characteristics = Input.Characteristics,
                Warning = Input.Warning,
                ModifiedDate = DateTime.Now
            };

            lionProfileService.Save(lionProfile);

            await hubContext.Clients.All.SendAsync("RefreshData", "create");

            return RedirectToPage("./Index");
        }

        private void LoadLionTypes()
        {
            var lionTypes = lionTypeService.GetLionTypes();
            LionTypes = new SelectList(lionTypes, "LionTypeId", "LionTypeName");
        }
    }
}
