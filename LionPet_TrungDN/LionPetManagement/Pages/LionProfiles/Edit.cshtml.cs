using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LionPetManagement_Repositories_DoanNgocTrung.DBContext;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LionPetManagement_DoanNgocTrung.Pages.LionProfiles
{
    [Authorize(Roles = "2")]

    public class EditModel : PageModel
    {
        //private readonly LionPetManagement_Repositories_DoanNgocTrung.DBContext.SU25LionDBContext _context;

        //public EditModel(LionPetManagement_Repositories_DoanNgocTrung.DBContext.SU25LionDBContext context)
        //{
        //    _context = context;
        //}

        private readonly ILionProfileService _lionProfileService;
        private readonly ILionTypeService _lionTypeService;

        public EditModel(ILionProfileService lionProfileService, ILionTypeService lionTypeService)
        {
            _lionProfileService = lionProfileService;
            _lionTypeService = lionTypeService;
        }

        [BindProperty]
        public LionProfile LionProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionprofile = await _lionProfileService.GetByIdAsync(id.Value);
            if (lionprofile == null)
            {
                return NotFound();
            }
            LionProfile = lionprofile;
            var liontypes = await _lionTypeService.GetAllAsync();
            ViewData["LionTypeId"] = new SelectList(liontypes, "LionTypeId", "LionTypeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var liontypes = await _lionTypeService.GetAllAsync();
                ViewData["LionTypeId"] = new SelectList(liontypes, "LionTypeId", "LionTypeName");
                return Page();
            }

            try
            {
                await _lionProfileService.UpdateAsync(LionProfile);
            }
  
            catch (DbUpdateConcurrencyException)
            {
                var existing = await _lionProfileService.GetByIdAsync(LionProfile.LionProfileId);
                if (existing == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
