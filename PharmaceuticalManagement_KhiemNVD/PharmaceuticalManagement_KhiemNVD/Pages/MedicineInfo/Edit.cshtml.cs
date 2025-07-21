using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PharmaceuticalManagement_Repository.DBContext;
using PharmaceuticalManagement_Repository.Models;
using PharmaceuticalManagement_Service.Interfaces;

namespace PharmaceuticalManagement_KhiemNVD.Pages.MedicineInfo
{
    [Authorize(Roles = "2")]

    public class EditModel : PageModel
    {
        private readonly IMedicineInformationService _medicineInformationService;
        private readonly IManufacturerService _manufacturerService;

        public EditModel(IMedicineInformationService medicineInformationService, IManufacturerService manufacturerService)
        {
            _medicineInformationService = medicineInformationService;
            _manufacturerService = manufacturerService;
        }

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionprofile = await _medicineInformationService.GetByIdAsync(id);
            if (lionprofile == null)
            {
                return NotFound();
            }
            MedicineInformation = lionprofile;
            var manufacturer = await _manufacturerService.GetAllAsync();
            ViewData["ManufacturerId"] = new SelectList(manufacturer, "ManufacturerId", "ManufacturerName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var manufacturer = await _manufacturerService.GetAllAsync();
                ViewData["ManufacturerId"] = new SelectList(manufacturer, "ManufacturerId", "ManufacturerName");
                return Page();
            }

            try
            {
                await _medicineInformationService.UpdateAsync(MedicineInformation);
            }

            catch (DbUpdateConcurrencyException)
            {
                var existing = await _medicineInformationService.GetByIdAsync(MedicineInformation.MedicineId);
                if (existing == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
