using System.Collections.Generic;
using BLAG.Common.Models.Question;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionText")]
    public class QuestionTextController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionTextController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/QuestionText
        [HttpGet]
        public IEnumerable<QuestionText> Get()
        {
            return _db.Fetch<QuestionText>();
        }

        // GET: api/QuestionText/5
        [HttpGet("{id}")]
        public QuestionText Get(int id)
        {
            return _db.SingleById<QuestionText>(id);
        }

        // POST: api/QuestionText
        [HttpPost]
        public void Post([FromBody] QuestionText questionText)
        {
            _db.Insert(questionText);
        }

        // PUT: api/QuestionText/5
        [HttpPut]
        public void Put([FromBody] QuestionText questionText)
        {
            _db.Update(questionText);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<QuestionText>(id);
        }
    }
}