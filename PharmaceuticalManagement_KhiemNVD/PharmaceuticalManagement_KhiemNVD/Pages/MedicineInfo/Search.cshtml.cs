using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;
using PharmaceuticalManagement_Service.Interfaces;

namespace PharmaceuticalManagement_KhiemNVD.Pages.MedicineInfo
{
    [Authorize(Roles = "2,3")]
    public class SearchModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;

        public SearchModel(IMedicineInformationService medicineInformationService)
        {
            _medicineInformationService = medicineInformationService;
        }
        public IList<MedicineInformation> MedicineInformation { get; set; } = new List<MedicineInformation>();

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        private const int PageSize = 3;

        public async Task OnGetAsync(string? medicineInformation, string? expirationDate, string? warningsAndPrecautions)
        {
            MedicineInformation = (await _medicineInformationService.SearchAsync(medicineInformation, expirationDate, warningsAndPrecautions))
                            .OrderBy(x => x.ExpirationDate)
                            .ToList();
            TotalPages = (int)Math.Ceiling(MedicineInformation.Count() / (double)PageSize);
        }
    }
}
