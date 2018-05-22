using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionVideo")]
    public class QuestionVideoController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionVideoController(LiteRepository db)
        {
            this._db = db;
        }
        // GET: api/QuestionVideo
        [HttpGet]
        public IEnumerable<QuestionVideo> Get()
        {
            return _db.Fetch<QuestionVideo>();
        }

        // GET: api/QuestionVideo/5
        [HttpGet("{id}")]
        public QuestionVideo Get(int id)
        {
            return _db.SingleById<QuestionVideo>(id);
        }
        
        // POST: api/QuestionVideo
        [HttpPost]
        public void Post([FromBody]QuestionVideo questionVideo)
        {
            _db.Insert(questionVideo);
        }
        
        // PUT: api/QuestionVideo/5
        [HttpPut]
        public void Put([FromBody]QuestionVideo questionVideo)
        {
            _db.Update(questionVideo);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<QuestionVideo>(id);
        }
    }
}
