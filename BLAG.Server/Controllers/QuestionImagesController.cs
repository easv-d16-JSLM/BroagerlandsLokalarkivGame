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
    [Route("api/QuestionImages")]
    public class QuestionImagesController : Controller
    {
        private readonly BlagContext _context;

        public QuestionImagesController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/QuestionImages
        [HttpGet]
        public IEnumerable<QuestionImage> GetQuestionImages()
        {
            return _context.QuestionImages;
        }

        // GET: api/QuestionImages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionImage = await _context.QuestionImages.SingleOrDefaultAsync(m => m.Id == id);

            if (questionImage == null)
            {
                return NotFound();
            }

            return Ok(questionImage);
        }

        // PUT: api/QuestionImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionImage([FromRoute] int id, [FromBody] QuestionImage questionImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionImageExists(id))
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

        // POST: api/QuestionImages
        [HttpPost]
        public async Task<IActionResult> PostQuestionImage([FromBody] QuestionImage questionImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionImages.Add(questionImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionImage", new { id = questionImage.Id }, questionImage);
        }

        // DELETE: api/QuestionImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionImage = await _context.QuestionImages.SingleOrDefaultAsync(m => m.Id == id);
            if (questionImage == null)
            {
                return NotFound();
            }

            _context.QuestionImages.Remove(questionImage);
            await _context.SaveChangesAsync();

            return Ok(questionImage);
        }

        private bool QuestionImageExists(int id)
        {
            return _context.QuestionImages.Any(e => e.Id == id);
        }
    }
}