using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using service;
using service.Interfaces;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        IGravaPedidoService pedidoSrv;
        IMemoryCache cache;
        public ChatHub(IGravaPedidoService _srv, IMemoryCache _cache)
        {
            pedidoSrv = _srv;
            cache = _cache;
        }
        public async Task SendMessage(string user, string message)
        {
            message = cache.Get<string>("loadedOdds") ?? "";
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
    
}