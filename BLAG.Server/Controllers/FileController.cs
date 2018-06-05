using System;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/File")]
    public class FileController : Controller
    {
        private readonly LiteRepository _db;

        public FileController(LiteRepository db)
        {
            _db = db;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _db.FileStorage.Delete(id);
        }

        // GET: api/File/5
        [HttpGet("{id}")]
        public FileStreamResult Get(string id)
        {
            var fi = _db.FileStorage.FindById(id);
            var stream = _db.FileStorage.OpenRead(id);
            return File(stream, fi.MimeType, fi.Filename);
        }

        // POST: api/File
        [HttpPost]
        public LiteFileInfo Post(IFormFile file)
        {
            var fi = _db.FileStorage.Upload(Guid.NewGuid().ToString(), file.FileName, file.OpenReadStream());
            return fi;
        }
    }
}