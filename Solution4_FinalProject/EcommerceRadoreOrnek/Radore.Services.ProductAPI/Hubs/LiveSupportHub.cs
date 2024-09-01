using Microsoft.AspNetCore.SignalR;
using Radore.Services.ProductAPI.Models;

namespace Radore.Services.ProductAPI.Hubs
{
    public class LiveSupportHub : Hub
    {
        private static int ClientCount { get; set; } = 0;

        public async Task SendMessage(string message) //HubMessageModel i başlangıç aşaması için kullanmadık.
        {
            await Clients.All.SendAsync("ReceiveMessage", message); // Gelen mesajı tüm bağlı istemcilere yayınlar
        }

        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}