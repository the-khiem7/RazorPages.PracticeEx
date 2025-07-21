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
    [Authorize(Roles = "2")]
    public class DeleteModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;
        //private readonly ILionTypeService _iLionTypeService;


        public DeleteModel(IMedicineInformationService medicineInformationService)
        {
            _medicineInformationService = medicineInformationService;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineInformation = await _medicineInformationService.GetByIdAsync(id);

            if (medicineInformation == null)
            {
                return NotFound();
            }
            else
            {
                MedicineInformation = medicineInformation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineInformation = await _medicineInformationService.GetByIdAsync(id);
            if (id != null)
            {
                MedicineInformation = medicineInformation;
                var result = await _medicineInformationService.DeleteAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
