using System;
using System.Linq;
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

        // GET: api/GameSession/5
        [HttpGet("{id}")]
        public GameSession Get(int id)
        {
            var questionnaire = _db.SingleById<Questionnaire>(id);
            var newGameSession = new GameSession();
            newGameSession.Questionnaire = questionnaire;
            newGameSession.JoinCode = GenerateJoinCode();
            _db.Insert(newGameSession);
            return _db.Fetch<GameSession>().LastOrDefault();
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