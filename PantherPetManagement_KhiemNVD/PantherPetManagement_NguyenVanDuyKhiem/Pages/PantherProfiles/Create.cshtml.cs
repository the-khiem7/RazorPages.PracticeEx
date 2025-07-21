using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PantherPetManagement_Repository.DBContext;
using PantherPetManagement_Repository.Models;
using PantherPetManagement_Service.Interfaces;

namespace PantherPetManagement_NguyenVanDuyKhiem.Pages.PantherProfiles
{
    [Authorize(Roles = "2")]

    public class CreateModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private readonly IPantherTypeService _pantherTypeService;

        public CreateModel(IPantherProfileService pantherProfileService, IPantherTypeService pantherTypeService)
        {
            _pantherProfileService = pantherProfileService;
            _pantherTypeService = pantherTypeService;
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = new PantherProfile();

        public async Task<IActionResult> OnGetAsync()
        {

            var pantherTypes = await _pantherTypeService.GetAllAsync();
            ViewData["PantherTypeId"] = new SelectList(pantherTypes, "PantherTypeId", "PantherTypeId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _pantherProfileService.CreateAsync(PantherProfile);

            return RedirectToPage("./Index");
        }
    }
}
