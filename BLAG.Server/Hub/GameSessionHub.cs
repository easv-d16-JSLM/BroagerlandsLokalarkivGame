using System;
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
            await Clients.Groups("Players" + session.JoinCode, "Server" + session.JoinCode).SendAsync("PlayerCountUpdated", _db.Fetch<Player>().Count(p => p.GameSession.Id == session.Id));

            return _db.SingleById<Player>(id);
        }

        private async void LeaderBoards(int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            var leaderboard = from player in _db.Fetch<Player>()
                where player.GameSession.Id.Equals(currentSessionId)
                orderby player.Score descending
                select player;
            await Clients.Groups("Players" + currentSession.JoinCode, "Server" + currentSession.JoinCode).SendAsync("CurrentLeaderboard", leaderboard);

            await Task.Delay(TimeSpan.FromSeconds(10));
            if (currentSession.CurrentQuestionIndex < currentSession.Questionnaire.Questions.Count)
                NextQuestion(currentSessionId);
        }

        private async void NextQuestion(int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            var qi = currentSession.CurrentQuestionIndex;
            var question = currentSession.Questionnaire.Questions[qi];
            var answer = _db.Single<Answer>(ans => ans.Question.Id == question.Id);
            var delaySeconds = question.Time.Seconds;
            var endTime = DateTime.Now.AddSeconds(delaySeconds).ToUniversalTime();
            await Task.WhenAll(
                Clients.Group("Players" + currentSession.JoinCode).SendAsync("CurrentAnswer", answer, endTime),
                Clients.Group("Server" + currentSession.JoinCode).SendAsync("CurrentQuestion", question, endTime),
                Task.Delay(delaySeconds));
            currentSession.CurrentQuestionIndex++;
            _db.Update(currentSession);
            LeaderBoards(currentSessionId);
        }


        public void StartGame(int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            currentSession.StartTime = DateTime.Now;
            _db.Update(currentSession);
            LeaderBoards(currentSessionId);
        }


        public async Task SubmitAnswer(PlayerAnswer answer, int currentSessionId)
        {
            var currentSession = _db.SingleById<GameSession>(currentSessionId);
            _db.Insert(answer);
            await Clients.Groups("Players" + currentSession.JoinCode, "Server" + currentSession.JoinCode).SendAsync("PlayerCountUpdated", _db.Fetch<Player>().Count(p=>p.GameSession.Id==currentSessionId));
        }
    }
}