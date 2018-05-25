using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.SignalR;

namespace BLAG.Server.Hub
{
    public class GameSessionHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly LiteRepository _db;

        public GameSessionHub(LiteRepository db)
        {
            _db = db;
        }
        
        public async Task CreateGameSession(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task JoinGameSession(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task StartGame(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}