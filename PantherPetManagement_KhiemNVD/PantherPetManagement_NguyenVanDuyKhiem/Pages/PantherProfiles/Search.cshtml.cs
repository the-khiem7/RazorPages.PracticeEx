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
    public class SearchModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;

        public SearchModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }
        public IList<PantherProfile> PantherProfile { get; set; } = new List<PantherProfile>();

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        private const int PageSize = 3;

        public async Task OnGetAsync(double? weight, string? pantherTypeName)
        {
            PantherProfile = (await _pantherProfileService.SearchAsync(weight, pantherTypeName))
                            .OrderByDescending(x => x.PantherProfileId)
                            .ToList();
            TotalPages = (int)Math.Ceiling(PantherProfile.Count() / (double)PageSize);
        }
    }
}
