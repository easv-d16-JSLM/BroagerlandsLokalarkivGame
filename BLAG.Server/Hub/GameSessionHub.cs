using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BLAG.Server.Hub
{
    public class GameSessionHub : Microsoft.AspNetCore.SignalR.Hub
    {

        // Phase 1 methods ///
        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //////////////////////

        // Phase 2 methods ///

        //////////////////////

        // Phase 3 methods ///

        //////////////////////


        // Phase 4 methods ///

        //////////////////////

    }
}
