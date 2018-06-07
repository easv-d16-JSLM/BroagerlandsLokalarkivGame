using System;
using System.Linq;
using System.Threading.Tasks;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BLAG.Server.Hub
{
    public class GameSessionHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly LiteRepository _db;
        private readonly ILogger<GameSessionHub> _logger;

        public GameSessionHub(LiteRepository db, ILogger<GameSessionHub> logger)
        {
            _db = db;
            _logger = logger;
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

        public async Task<Player> JoinGameSession(string userName, string joinCode)
        {
            GameSession session;
            try
            {
                session = _db.Single<GameSession>(gs => gs.JoinCode == joinCode);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            var id = _db.Insert(new Player {Name = userName, GameSession = session});
            await Groups.AddToGroupAsync(Context.ConnectionId, "Players" + joinCode);
            await Clients.Groups("Players" + session.JoinCode, "Server" + session.JoinCode)
                .SendAsync("PlayerCountUpdated", _db.Fetch<Player>().Count(p => p.GameSession.Id == session.Id));

            return _db.SingleById<Player>(id);
        }

        private static async void LeaderBoards(int currentSessionId, LiteRepository db, IHubCallerClients clients,
            ILogger log)
        {
            log.LogWarning("Showing Leaderboards");
            var currentSession = db.SingleById<GameSession>(currentSessionId);
            var leaderboard = from player in db.Fetch<Player>()
                where player.GameSession.Id.Equals(currentSessionId)
                orderby player.Score descending
                select player;
            await clients.Groups("Players" + currentSession.JoinCode, "Server" + currentSession.JoinCode)
                .SendAsync("CurrentLeaderboard", leaderboard.ToList();

            await Task.Delay(TimeSpan.FromSeconds(10));
            if (currentSession.CurrentQuestionIndex < currentSession.Questionnaire.Questions.Count)
                NextQuestion(currentSessionId, db, clients, log);
        }

        private static async void NextQuestion(int currentSessionId, LiteRepository db, IHubCallerClients clients,
            ILogger log)
        {
            log.LogWarning("Showing Question");
            var currentSession = db.SingleById<GameSession>(currentSessionId);
            var qi = currentSession.CurrentQuestionIndex;
            var question = currentSession.Questionnaire.Questions[qi];
            var answer = db.Single<Answer>(ans => ans.Question.Id == question.Id);
            var endTime = DateTime.Now.Add(question.Time).ToUniversalTime();
            await Task.WhenAll(
                clients.Group("Players" + currentSession.JoinCode).SendAsync("CurrentAnswer", answer, endTime),
                clients.Group("Server" + currentSession.JoinCode).SendAsync("CurrentQuestion", question, endTime),
                Task.Delay(question.Time));
            currentSession.CurrentQuestionIndex++;
            db.Update(currentSession);
            LeaderBoards(currentSessionId, db, clients, log);
        }


        public void StartGame(int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            currentSession.StartTime = DateTime.Now;
            _db.Update(currentSession);
            LeaderBoards(currentSessionId, _db, Clients, _logger);
        }


        public async Task SubmitAnswer(PlayerAnswer answer, int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            _db.Insert(answer);
            await Clients.Groups("Players" + currentSession.JoinCode, "Server" + currentSession.JoinCode)
                .SendAsync("PlayerCountUpdated", _db.Fetch<Player>().Count(p => p.GameSession.Id == currentSessionId));
        }
    }
}