using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_NguyenVanDuyKhiem.Pages.PantherProfiles
{
    [Authorize(Roles = "2")]
    public class DeleteModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;


        public DeleteModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherProfile = await _pantherProfileService.GetByIdAsync(id.Value);

            if (pantherProfile == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = pantherProfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherProfile = await _pantherProfileService.GetByIdAsync(id.Value);
            if (id != null)
            {
                PantherProfile = pantherProfile;
                var result = await _pantherProfileService.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
