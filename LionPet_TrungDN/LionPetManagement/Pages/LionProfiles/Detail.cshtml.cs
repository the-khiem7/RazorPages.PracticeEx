using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LionPetManagement_Repositories_DoanNgocTrung.DBContext;
using LionPetManagement_Repositories_DoanNgocTrung.Models;
using Microsoft.AspNetCore.Authorization;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;

namespace LionPetManagement_DoanNgocTrung.Pages.LionProfiles
{
    [Authorize(Roles = "2,3")]

    public class DetailModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;

        public DetailModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }
        public LionProfile LionProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var item = await _lionProfileService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = item;
                return Page();
            }
        }
    }
}
