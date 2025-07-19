using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LionPetManagement_Repositories_DoanNgocTrung.DBContext;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using LionPetManagement_Services_DoanNgocTrung.Services;
using Microsoft.AspNetCore.Authorization;

namespace LionPetManagement_DoanNgocTrung.Pages.LionProfiles
{
    [Authorize(Roles = "2")]
    public class DeleteModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;
        //private readonly ILionTypeService _iLionTypeService;


        public DeleteModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }

        [BindProperty]
        public LionProfile LionProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionProfile = await _lionProfileService.GetByIdAsync(id.Value);

            if (lionProfile == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = lionProfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionProfile = await _lionProfileService.GetByIdAsync(id.Value);
            if (id != null)
            {
                LionProfile = lionProfile;
                var result = await _lionProfileService.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
