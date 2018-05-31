using System;
using System.Threading.Tasks;
using BLAG.Common.Models;
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

        public async Task JoinGameSession(string userName, string joinCode)
        {
            try
            {
                var session = (from gameSession in _db.Query<GameSession>()
                    where gameSession.JoinCode.Equals(joinCode)
                    select gameSession).First();
                _db.Insert(new Player {Name = userName, GameSession = session});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, "Players" + joinCode);
            await OnConnectedAsync();
        }

        public async Task StartGame(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}