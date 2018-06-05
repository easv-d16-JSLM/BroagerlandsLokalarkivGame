using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Answer")]
    public class AnswerController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerController(LiteRepository db)
        {
            _db = db;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<Answer>(id);
        }

        // GET: api/Answer
        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return _db.Fetch<Answer>();
        }

        // GET: api/Answer/5
        [HttpGet("{id}")]
        public Answer Get(int id)
        {
            return _db.SingleById<Answer>(id);
        }

        // POST: api/Answer
        [HttpPost]
        public void Post([FromBody] Answer answer)
        {
            _db.Insert(answer);
        }

        // PUT: api/Answer/5
        [HttpPut]
        public void Put([FromBody] Answer answer)
        {
            _db.Update(answer);
        }
    }
}