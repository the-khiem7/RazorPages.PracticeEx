using BUL;
using LionPetManagement_StudentName.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LionPetManagement_StudentName.Pages.LionProfile
{
    public class DeleteModel : BasePageModel
    {
        private readonly ILionProfileService service;
        private readonly IHubContext<SignalHub> hubContext;

        public DeleteModel(ILionProfileService service, IHubContext<SignalHub> hubContext)
        {
            this.hubContext = hubContext;
            this.service = service;
        }

        [BindProperty]
        public BusinessObjects.LionProfile LionProfile { get; set; } = default!;

        public IActionResult OnGetAsync(int id)
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            var lionprofile = service.GetById(id);

            if (lionprofile == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = lionprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            var lionprofile = service.GetById(id);
            if (lionprofile == null)
            {
                return NotFound();
            }

            service.Delete(lionprofile);

            await hubContext.Clients.All.SendAsync("RefreshData", "delete");

            return RedirectToPage("./Index");
        }
    }
}
