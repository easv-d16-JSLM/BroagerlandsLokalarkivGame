using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<GameSession> CreateGameSession(int questionnaireId)
        {
            var questionnaire = _db.SingleById<Questionnaire>(questionnaireId);
            var newGameSession = new GameSession
            {
                Questionnaire = questionnaire
            };
            var id = _db.Insert(newGameSession);
            await Groups.AddToGroupAsync(Context.ConnectionId, "Server" + newGameSession.JoinCode);
            return _db.SingleById<GameSession>(id);
        }

        public IEnumerable<Player> CurrentLeaderboard(GameSession currentSession)
        {
            var leaderBoard = from player in _db.Fetch<Player>()
                where player.GameSession.Id.Equals(currentSession.Id)
                select player;

            return leaderBoard.Reverse();
        }

        public async Task<bool> JoinGameSession(string userName, string joinCode)
        {
            var session = (from gameSession in _db.Query<GameSession>()
                where gameSession.JoinCode.Equals(joinCode)
                select gameSession).First();

            _db.Insert(new Player {Name = userName, GameSession = session});

            await Groups.AddToGroupAsync(Context.ConnectionId, "Players" + joinCode);
            await Clients.All.SendAsync("PlayerCountUpdated", 1);

            return true;
        }

        public async Task StartGame(GameSession currentSession)
        {
            currentSession.StartTime = DateTime.Now;
            _db.Update(currentSession);

            await Clients.All.SendAsync("GameStarted");
        }
    }
}