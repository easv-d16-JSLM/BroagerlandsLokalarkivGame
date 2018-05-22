using System.Collections.Generic;
using BLAG.Common.Models.Question;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionImage")]
    public class QuestionImageController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionImageController(LiteRepository db)
        {
            _db = db;
        }

        // GET: api/QuestionImage
        [HttpGet]
        public IEnumerable<QuestionImage> Get()
        {
            return _db.Fetch<QuestionImage>();
        }

        // GET: api/QuestionImage/5
        [HttpGet("{id}")]
        public QuestionImage Get(int id)
        {
            return _db.SingleById<QuestionImage>(id);
        }

        // POST: api/QuestionImage
        [HttpPost]
        public void Post([FromBody] QuestionImage questionImage)
        {
            _db.Insert(questionImage);
        }

        // PUT: api/QuestionImage/5
        [HttpPut]
        public void Put([FromBody] QuestionImage questionImage)
        {
            _db.Update(questionImage);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<QuestionImage>(id);
        }
    }
}