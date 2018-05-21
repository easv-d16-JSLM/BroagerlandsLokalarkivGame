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
    [Route("api/AnswerMap")]
    public class AnswerMapController : Controller
    {
        private readonly LiteRepository _db;

        public AnswerMapController(LiteRepository db)
        {
            this._db = db;
        }

        // GET: api/AnswerMap
        [HttpGet]
        public IEnumerable<AnswerMap> Get()
        {
            return _db.Fetch<AnswerMap>();
        }

        // GET: api/AnswerMap/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/AnswerMap
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/AnswerMap/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
