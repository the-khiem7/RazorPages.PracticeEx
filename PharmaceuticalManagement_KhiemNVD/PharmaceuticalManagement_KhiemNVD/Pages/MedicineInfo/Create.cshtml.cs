using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;
using PharmaceuticalManagement_Service.Interfaces;

namespace PharmaceuticalManagement_KhiemNVD.Pages.MedicineInfo
{
    [Authorize(Roles = "2")]
    public class CreateModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;
        private readonly IManufacturerService _manufacturerService;

        public CreateModel(IMedicineInformationService medicineInformationService, IManufacturerService manufacturerService)
        {
            _medicineInformationService = medicineInformationService;
            _manufacturerService = manufacturerService;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = new MedicineInformation();

        public async Task<IActionResult> OnGetAsync()
        {

            var manufacturer = await _manufacturerService.GetAllAsync();
            ViewData["ManufacturerId"] = new SelectList(manufacturer, "ManufacturerId", "ManufacturerName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _medicineInformationService.CreateAsync(MedicineInformation);

            return RedirectToPage("./Index");
        }
    }
}
