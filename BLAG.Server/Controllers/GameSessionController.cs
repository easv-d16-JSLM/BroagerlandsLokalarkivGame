using System;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/GameSession")]
    public class GameSessionController : Controller
    {
        private readonly LiteRepository _db;

        public GameSessionController(LiteRepository db)
        {
            _db = db;
        }

        [HttpPost("{id}")]
        public GameSession Create(int questionnaireId)
        {
            var questionnaire = _db.SingleById<Questionnaire>(questionnaireId);
            var newGameSession = new GameSession
            {
                Questionnaire = questionnaire,
                JoinCode = GenerateJoinCode()
            };
            var id = _db.Insert(newGameSession);
            return _db.SingleById<GameSession>(id);
        }


        private string GenerateJoinCode()
        {
            var joinCode = "";
            var r = new Random();
            for (var i = 0; i < 5; i++)
            {
                var c = (char) (r.Next(26) + 'a');
                joinCode += c;
            }
            return joinCode;
        }
    }
}