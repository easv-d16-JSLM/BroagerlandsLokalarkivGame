using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/Question
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _db.Fetch<Question>();
        }

        // GET: api/Question
        [HttpGet("{id}")]
        public Question Get(int id)
        {
            return _db.SingleById<Question>(id);
        }

        // POST: api/Question
        [HttpPost]
        public void Post([FromBody] Question question)
        {
            _db.Insert(question);
        }

        // PUT: api/Question
        [HttpPut]
        public void Put([FromBody] Question question)
        {
            _db.Update(question);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<Question>(id);
        }
    }
}