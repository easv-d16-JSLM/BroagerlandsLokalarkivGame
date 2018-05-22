using System.Collections.Generic;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Questionnaire")]
    public class QuestionnaireController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionnaireController(LiteRepository db)
        {
            this._db = db;
        }

        // GET: api/Questionnaire
        [HttpGet]
        public IEnumerable<Questionnaire> Get()
        {
            return _db.Fetch<Questionnaire>();
        }

        // GET: api/Questionnaire/5
        [HttpGet("{id}")]
        public Questionnaire Get(int id)
        {
            return _db.SingleById<Questionnaire>(id);
        }
        
        // POST: api/Questionnaire
        [HttpPost]
        public void Post([FromBody]Questionnaire questionnaire)
        {
            _db.Insert(questionnaire);
        }
        
        // PUT: api/Questionnaire/5
        [HttpPut]
        public void Put([FromBody]Questionnaire questionnaire)
        {
            _db.Update(questionnaire);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<Questionnaire>(id);
        }
    }
}
