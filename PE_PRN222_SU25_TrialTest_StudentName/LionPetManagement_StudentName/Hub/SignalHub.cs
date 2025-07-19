using Microsoft.AspNetCore.SignalR;

namespace LionPetManagement_StudentName.Hub
{
    public class SignalHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task NotifyDataChanged(string operation)
        {
            await Clients.All.SendAsync("RefreshData", operation);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
