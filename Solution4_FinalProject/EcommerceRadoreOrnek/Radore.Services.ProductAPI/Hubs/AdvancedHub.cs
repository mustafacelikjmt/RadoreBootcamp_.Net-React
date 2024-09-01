using Microsoft.AspNetCore.SignalR;
using Radore.Services.ProductAPI.Models;
using System.Collections.Concurrent;

namespace Radore.Services.ProductAPI.Hubs
{
    public class AdvancedHub : Hub //burası geliştirmeleri bittikten sonra kullanıma alınıcak. ilk etapta daha basit bir destek servisi yazıcaz.
    {
        // Temsilcilerin bağlantı kimliklerini saklamak için bir yapı
        private static ConcurrentBag<string> _representativeConnections = new ConcurrentBag<string>();

        private static ConcurrentDictionary<string, string> _customerToRepresentative = new ConcurrentDictionary<string, string>();

        public async Task SendMessage(HubMessageModel messageModel)
        {
            if (messageModel.UserRole == "Customer")
            {
                // Müşteri mesajı, yalnızca atanmış temsilciye gönderilir
                if (_customerToRepresentative.TryGetValue(Context.ConnectionId, out var representativeConnectionId))
                {
                    await Clients.Client(representativeConnectionId).SendAsync("ReceiveMessage", messageModel);
                }
                else
                {
                    // Eğer müşteri için bir temsilci atanmadıysa, hata mesajı veya başka bir işlem yapılabilir
                    await Clients.Caller.SendAsync("Error", "No representative assigned.");
                }
            }
            else if (messageModel.UserRole == "Representative")
            {
                // Opsiyonel: Temsilciler arası mesajlaşma veya başka işlemler
            }
        }

        public async Task AssignRepresentative(string customerConnectionId)
        {
            // Temsilci bağlantılarından birini seçmek ve müşteri ile ilişkilendirmek
            if (_representativeConnections.TryPeek(out var representativeConnectionId))
            {
                _customerToRepresentative[customerConnectionId] = representativeConnectionId;
                await Clients.Client(customerConnectionId).SendAsync("RepresentativeAssigned", representativeConnectionId);
                await Clients.Client(representativeConnectionId).SendAsync("NewCustomer", customerConnectionId);
            }
            else
            {
                // Müşteri için atanacak bir temsilci yoksa hata mesajı gönder
                await Clients.Client(customerConnectionId).SendAsync("Error", "Lütfen bekleyin. Temsilci bağlanacak.");
            }
        }

        public async Task AddRepresentative()
        {
            // Temsilci bağlantısını listeye ekler
            _representativeConnections.Add(Context.ConnectionId);
            await Clients.Caller.SendAsync("AddedToRepresentativeList");
        }

        public async Task RemoveRepresentative()
        {
            // Temsilci bağlantısını listeden çıkarır
            _representativeConnections = new ConcurrentBag<string>(_representativeConnections.Where(id => id != Context.ConnectionId));
            _customerToRepresentative = new ConcurrentDictionary<string, string>(_customerToRepresentative.Where(kv => kv.Value != Context.ConnectionId));
            await Clients.Caller.SendAsync("RemovedFromRepresentativeList");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Bağlantı koparsa, temsilci listesi güncellenir ve müşteri-temsilci eşleşmesi kaldırılır
            if (_representativeConnections.Contains(Context.ConnectionId))
            {
                _representativeConnections = new ConcurrentBag<string>(_representativeConnections.Where(id => id != Context.ConnectionId));
                _customerToRepresentative = new ConcurrentDictionary<string, string>(_customerToRepresentative.Where(kv => kv.Value != Context.ConnectionId));
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}