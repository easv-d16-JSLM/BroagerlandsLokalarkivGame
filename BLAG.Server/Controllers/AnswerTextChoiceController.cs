using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/AnswerTextChoice")]
    public class AnswerTextChoiceController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerTextChoiceController(LiteRepository db)
        {
            this._db = db;
        }
        // GET: api/AnswerTextChoice
        [HttpGet]
        public IEnumerable<AnswerTextChoice> Get()
        {
            return _db.Fetch<AnswerTextChoice>();
        }

        // GET: api/AnswerTextChoice/5
        [HttpGet("{id}")]
        public AnswerTextChoice Get(int id)
        {
            return _db.SingleById<AnswerTextChoice>(id);
        }
        
        // POST: api/AnswerTextChoice
        [HttpPost]
        public void Post([FromBody]AnswerTextChoice answerTextChoice)
        {
            _db.Insert(answerTextChoice);
        }
        
        // PUT: api/AnswerTextChoice/5
        [HttpPut]
        public void Put([FromBody]AnswerTextChoice answerTextChoice)
        {
            _db.Update(answerTextChoice);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<AnswerTextChoice>(id);
        }
    }
}
