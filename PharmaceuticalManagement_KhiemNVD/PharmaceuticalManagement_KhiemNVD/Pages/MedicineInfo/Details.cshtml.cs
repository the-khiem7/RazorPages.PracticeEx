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

    public class DetailsModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;

        public DetailsModel(IMedicineInformationService medicineInformationService)
        {
            _medicineInformationService = medicineInformationService;
        }
        public MedicineInformation MedicineInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var item = await _medicineInformationService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = item;
                return Page();
            }
        }
    }
}
