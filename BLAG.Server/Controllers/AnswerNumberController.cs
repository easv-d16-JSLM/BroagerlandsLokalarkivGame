using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/AnswerNumber")]
    public class AnswerNumberController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerNumberController(LiteRepository db)
        {
            this._db = db;
        }

        // GET: api/AnswerNumber
        [HttpGet]
        public IEnumerable<AnswerNumber> Get()
        {
            return _db.Fetch<AnswerNumber>();
        }

        // GET: api/AnswerNumber/5
        [HttpGet("{id}")]
        public AnswerNumber Get(int id)
        {
            return _db.SingleById<AnswerNumber>(id);
        }
        
        // POST: api/AnswerNumber
        [HttpPost]
        public void Post([FromBody]AnswerNumber answerNumber)
        {
            _db.Insert(answerNumber);
        }
        
        // PUT: api/AnswerNumber/5
        [HttpPut]
        public void Put([FromBody]AnswerNumber answerNumber)
        {
            _db.Update(answerNumber);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<AnswerNumber>(id);
        }
    }
}
