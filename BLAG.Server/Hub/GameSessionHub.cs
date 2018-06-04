using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
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

        public IEnumerable<Player> CurrentLeaderboard(int gameSessionId)
        {
            var leaderBoard = from player in _db.Fetch<Player>()
                where player.GameSession.Id.Equals(gameSessionId)
                select player;

            return leaderBoard.Reverse();
        }

        public async Task<bool> JoinGameSession(string userName, string joinCode)
        {
            var session = _db.Single<GameSession>(gs => gs.JoinCode == joinCode);
            _db.Insert(new Player {Name = userName, GameSession = session});

            await Groups.AddToGroupAsync(Context.ConnectionId, "Players" + joinCode);
            await Clients.All.SendAsync("PlayerCountUpdated", 1);

            return true;
        }

        public async void SubmitAnswer(PlayerAnswer answer)
        {
            _db.Insert(answer);

            await Clients.All.SendAsync("PlayerCountUpdated", 1); 
        }

        public async void StartGame(int currentSessionId)
        {
            var currentSession =_db.SingleById<GameSession>(currentSessionId);
            currentSession.StartTime = DateTime.Now;
            _db.Update(currentSession);

            await Clients.All.SendAsync("CurrentLeaderboard",null);

            var t = new Timer(10000);
            t.Elapsed += async (sender, args) =>
            {
                await Clients.All.SendAsync("CurrentQuestion",null,null);
                
            };
            t.Start();
        }

    }
}