using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_NguyenVanDuyKhiem.Pages.PantherProfiles
{
    [Authorize(Roles = "2")]

    public class EditModel : PageModel
    {

        private readonly IPantherProfileService _pantherProfileService;
        private readonly IPantherTypeService _pantherTypeService;

        public EditModel(IPantherProfileService pantherProfileService, IPantherTypeService pantherTypeService)
        {
            _pantherProfileService = pantherProfileService;
            _pantherTypeService = pantherTypeService;
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = await _pantherProfileService.GetByIdAsync(id.Value);
            if (pantherprofile == null)
            {
                return NotFound();
            }
            PantherProfile = pantherprofile;
            var panthertypes = await _pantherTypeService.GetAllAsync();

            ViewData["PantherTypeId"] = new SelectList(panthertypes, "PantherTypeId", "PantherTypeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var panthertypes = await _pantherTypeService.GetAllAsync();
                ViewData["PantherTypeId"] = new SelectList(panthertypes, "PantherTypeId", "PantherTypeName");
                return Page();
            }

            try
            {
                await _pantherProfileService.UpdateAsync(PantherProfile);
            }

            catch (DbUpdateConcurrencyException)
            {
                var existing = await _pantherProfileService.GetByIdAsync(PantherProfile.PantherProfileId);
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
