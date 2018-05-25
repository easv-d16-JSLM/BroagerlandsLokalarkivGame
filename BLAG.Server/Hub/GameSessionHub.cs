using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BLAG.Server.Hub
{
    public class GameSessionHub : Microsoft.AspNetCore.SignalR.Hub
    {


        #region Phase 1
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
        #endregion
    }
}