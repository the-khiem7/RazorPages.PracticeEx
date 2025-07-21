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
    [Authorize(Roles = "2,3")]

    public class DetailsModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;

        public DetailsModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }
        public PantherProfile PantherProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var item = await _pantherProfileService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = item;
                return Page();
            }
        }
    }
}
