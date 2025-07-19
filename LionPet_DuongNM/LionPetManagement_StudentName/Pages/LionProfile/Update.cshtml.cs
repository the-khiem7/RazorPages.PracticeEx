using BUL;
using LionPetManagement_StudentName.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class UpdateModel : BasePageModel
    {
        private readonly ILionProfileService _lionProfileService;
        private readonly ILionTypeService _lionTypeService;
        private readonly IHubContext<SignalHub> hubContext;

        public UpdateModel(ILionProfileService lionProfileService, ILionTypeService lionTypeService, IHubContext<SignalHub> hubContext)
        {
            _lionProfileService = lionProfileService;
            _lionTypeService = lionTypeService;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public LionProfileInput Input { get; set; }

        public SelectList LionTypes { get; set; }

        public class LionProfileInput
        {
            public int LionProfileId { get; set; }

            [Required(ErrorMessage = "Lion Name is required")]
            [MinLength(4, ErrorMessage = "Lion Name must be at least 4 characters")]
            public string LionName { get; set; }

            [Required(ErrorMessage = "Weight is required")]
            [Range(30.1, double.MaxValue, ErrorMessage = "Weight must be greater than 30")]
            public double Weight { get; set; }

            [Required(ErrorMessage = "Lion Type is required")]
            public int LionTypeId { get; set; }

            public string Characteristics { get; set; }
            public string Warning { get; set; }
        }

        public IActionResult OnGet(int id)
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            var lionProfile = _lionProfileService.GetById(id);
            if (lionProfile == null)
            {
                return NotFound();
            }

            Input = new LionProfileInput
            {
                LionProfileId = lionProfile.LionProfileId,
                LionName = lionProfile.LionName,
                Weight = lionProfile.Weight,
                LionTypeId = lionProfile.LionTypeId,
                Characteristics = lionProfile.Characteristics,
                Warning = lionProfile.Warning
            };

            LoadLionTypes();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            // Custom validation for LionName (same as Create)
            if (!string.IsNullOrEmpty(Input.LionName))
            {
                if (Regex.IsMatch(Input.LionName, @"[#@&()]"))
                {
                    ModelState.AddModelError("Input.LionName", "Lion Name cannot contain special characters (#, @, &, (, ))");
                }

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

            var lionProfile = _lionProfileService.GetById(Input.LionProfileId);
            if (lionProfile == null)
            {
                return NotFound();
            }

            lionProfile.LionName = Input.LionName;
            lionProfile.Weight = Input.Weight;
            lionProfile.LionTypeId = Input.LionTypeId;
            lionProfile.Characteristics = Input.Characteristics;
            lionProfile.Warning = Input.Warning;
            lionProfile.ModifiedDate = DateTime.Now;

            _lionProfileService.Update(lionProfile);
            await hubContext.Clients.All.SendAsync("RefreshData", "update");

            return RedirectToPage("Index");
        }

        private void LoadLionTypes()
        {
            var lionTypes = _lionTypeService.GetLionTypes();
            LionTypes = new SelectList(lionTypes, "LionTypeId", "LionTypeName");
        }
    }
}
