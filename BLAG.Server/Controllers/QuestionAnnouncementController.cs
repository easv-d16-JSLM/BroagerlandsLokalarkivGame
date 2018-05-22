using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLAG.Common.Models;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/QuestionAnnouncement")]
    public class QuestionAnnouncementController : Controller
    {
        private readonly LiteRepository _db;

        public QuestionAnnouncementController(LiteRepository db)
        {
            this._db = db;
        }

        // GET: api/QuestionAnnouncement
        [HttpGet]
        public IEnumerable<QuestionAnnouncement> Get()
        {
            return _db.Fetch<QuestionAnnouncement>();
        }

        // GET: api/QuestionAnnouncement/5
        [HttpGet("{id}")]
        public QuestionAnnouncement Get(int id)
        {
            return _db.SingleById<QuestionAnnouncement>(id);
        }
        
        // POST: api/QuestionAnnouncement
        [HttpPost]
        public void Post([FromBody]QuestionAnnouncement questionAnnouncement)
        {
            _db.Insert(questionAnnouncement);
        }
        
        // PUT: api/QuestionAnnouncement/5
        [HttpPut]
        public void Put([FromBody]QuestionAnnouncement questionAnnouncement)
        {
            _db.Update(questionAnnouncement);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Delete<QuestionAnnouncement>(id);
        }
    }
}
