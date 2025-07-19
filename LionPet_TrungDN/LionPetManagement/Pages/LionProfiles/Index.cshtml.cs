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
    [Authorize(Roles = "2,3")]
    public class IndexModel : PageModel
    {
        private readonly ILionProfileService _lionProfileService;

        public IndexModel(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }
        public IList<LionProfile> LionProfile { get; set; } = new List<LionProfile>();

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        private const int PageSize = 3;

        //sorting newest (ko có id thì có thể sắp xếp theo tên hoặc ngày tạo)
        //search 2 trường độc lập: LionTypeName, Weight

        public async Task OnGetAsync(string? lionTypeName, double? weight)
        {
            LionProfile = (await _lionProfileService.SearchAsync(lionTypeName, weight))
                            .OrderByDescending(x => x.LionProfileId)
                            .ToList();
            TotalPages = (int)Math.Ceiling(LionProfile.Count() / (double)PageSize);
        }

        //search chung trường
        //public async Task OnGetAsync(string? searchQuery)
        //{
        //    LionProfile = (await _lionProfileService.SearchAsync(searchQuery))
        //                    .OrderByDescending(x => x.LionProfileId)
        //                    .ToList();
        //    TotalPages = (int)Math.Ceiling(LionProfile.Count() / (double)PageSize);
        //}
    }
}
//Hàm ko có search, sorting newest
//public async Task OnGetAsync()
//{
//    LionProfile = (await _lionProfileService.GetAllAsync())
//                    .OrderByDescending(x => x.LionProfileId)
//                    .ToList();
//    TotalPages = (int)Math.Ceiling(LionProfile.Count() / (double)PageSize);
//}

//basic chỉ có phân trang
//public async Task OnGetAsync()
//{
//    LionProfile = await _lionProfileService.GetAllAsync();
//    TotalPages = (int)Math.Ceiling(LionProfile.Count() / (double)PageSize);
//}
