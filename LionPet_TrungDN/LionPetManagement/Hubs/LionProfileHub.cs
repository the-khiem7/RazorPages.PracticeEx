using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
namespace LionPetManagement_DoanNgocTrung.Hubs
{
    public class LionProfileHub : Hub
    {
        private readonly ILionProfileService _lionProfileService;

        public LionProfileHub(ILionProfileService lionProfileService)
        {
            _lionProfileService = lionProfileService;
        }

        public async Task HubDelete_LionProfile(string LionProfileid)
        {
            await Clients.All.SendAsync("Receiver_DeleteProfileService", LionProfileid);

            await _lionProfileService.DeleteAsync(int.Parse(LionProfileid));

        }

    }
}
