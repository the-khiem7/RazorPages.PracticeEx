using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace LionPetManagement_DoanNgocTrung.Pages.LionProfiles
{
    [Authorize(Roles = "2")]

    public class CreateModel : PageModel
    {
        //private readonly LionPetManagement_Repositories_DoanNgocTrung.DBContext.SU25LionDBContext _context;

        //public CreateModel(LionPetManagement_Repositories_DoanNgocTrung.DBContext.SU25LionDBContext context)
        //{
        //    _context = context;
        //}

        private readonly ILionProfileService _lionProfileService;
        private readonly ILionTypeService _lionTypeService;

        public CreateModel(ILionProfileService lionProfileService, ILionTypeService lionTypeService)
        {
            _lionProfileService = lionProfileService;
            _lionTypeService = lionTypeService;
        }

        [BindProperty]
        public LionProfile LionProfile { get; set; } = new LionProfile();

        public async Task<IActionResult> OnGetAsync()
        {

            var lionTypes = await _lionTypeService.GetAllAsync();
            ViewData["LionTypeId"] = new SelectList(lionTypes, "LionTypeId", "LionTypeId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _lionProfileService.CreateAsync(LionProfile);
            
            return RedirectToPage("./Index");
        }
    }
}

