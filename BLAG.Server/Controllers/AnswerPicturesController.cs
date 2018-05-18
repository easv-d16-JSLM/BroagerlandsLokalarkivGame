using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLAG.Common.Models;
using BLAG.Server.Data;

namespace BLAG.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/AnswerPictures")]
    public class AnswerPicturesController : Controller
    {
        private readonly BlagContext _context;

        public AnswerPicturesController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/AnswerPictures
        [HttpGet]
        public IEnumerable<AnswerPicture> GetAnswerPictures()
        {
            return _context.AnswerPictures;
        }

        // GET: api/AnswerPictures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerPicture([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerPicture = await _context.AnswerPictures.SingleOrDefaultAsync(m => m.Id == id);

            if (answerPicture == null)
            {
                return NotFound();
            }

            return Ok(answerPicture);
        }

        // PUT: api/AnswerPictures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerPicture([FromRoute] int id, [FromBody] AnswerPicture answerPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerPicture.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerPictureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnswerPictures
        [HttpPost]
        public async Task<IActionResult> PostAnswerPicture([FromBody] AnswerPicture answerPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AnswerPictures.Add(answerPicture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerPicture", new { id = answerPicture.Id }, answerPicture);
        }

        // DELETE: api/AnswerPictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerPicture([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerPicture = await _context.AnswerPictures.SingleOrDefaultAsync(m => m.Id == id);
            if (answerPicture == null)
            {
                return NotFound();
            }

            _context.AnswerPictures.Remove(answerPicture);
            await _context.SaveChangesAsync();

            return Ok(answerPicture);
        }

        private bool AnswerPictureExists(int id)
        {
            return _context.AnswerPictures.Any(e => e.Id == id);
        }
    }
}