using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionAudio")]
    public class QuestionAudioController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionAudioController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/QuestionAudio
        [HttpGet]
        public IEnumerable<QuestionAudio> Get()
        {
            return _db.Fetch<QuestionAudio>();
        }

        // GET: api/QuestionAudio/5
        [HttpGet("{id}")]
        public QuestionAudio Get(int id)
        {
            return _db.SingleById<QuestionAudio>(id);
        }

        // POST: api/QuestionAudio
        [HttpPost]
        public void Post([FromBody] QuestionAudio questionAudio)
        {
            _db.Insert(questionAudio);
        }

        // PUT: api/QuestionAudio/5
        [HttpPut]
        public void Put([FromBody] QuestionAudio questionAudio)
        {
            _db.Update(questionAudio);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<QuestionAudio>(id);
        }
    }
}