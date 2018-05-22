using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/AnswerPicture")]
    public class AnswerPictureController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerPictureController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/AnswerPicture
        [HttpGet]
        public IEnumerable<AnswerPicture> Get()
        {
            return _db.Fetch<AnswerPicture>();
        }

        // GET: api/AnswerPicture/5
        [HttpGet("{id}")]
        public AnswerPicture Get(int id)
        {
            return _db.SingleById<AnswerPicture>(id);
        }

        // POST: api/AnswerPicture
        [HttpPost]
        public void Post([FromBody] AnswerPicture answerPicture)
        {
            _db.Insert(answerPicture);
        }

        // PUT: api/AnswerPicture/5
        [HttpPut]
        public void Put([FromBody] AnswerPicture answerPicture)
        {
            _db.Update(answerPicture);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<AnswerPicture>(id);
        }
    }
}