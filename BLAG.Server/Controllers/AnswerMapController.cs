using System.Collections.Generic;
using BLAG.Common.Models.Answer;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/AnswerMap")]
    public class AnswerMapController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerMapController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/AnswerMap
        [HttpGet]
        public IEnumerable<AnswerMap> Get()
        {
            return _db.Fetch<AnswerMap>();
        }

        // GET: api/AnswerMap/5
        [HttpGet("{id}")]
        public AnswerMap Get(int id)
        {
            return _db.SingleById<AnswerMap>(id);
        }

        // POST: api/AnswerMap
        [HttpPost]
        public void Post([FromBody] AnswerMap answerMap)
        {
            _db.Insert(answerMap);
        }

        // PUT: api/AnswerMap/5
        [HttpPut]
        public void Put([FromBody] AnswerMap answerMap)
        {
            _db.Update(answerMap);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<AnswerMap>(id);
        }
    }
}