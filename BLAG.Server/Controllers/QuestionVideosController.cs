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
    [Route("api/QuestionVideos")]
    public class QuestionVideosController : Controller
    {
        private readonly BlagContext _context;

        public QuestionVideosController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/QuestionVideos
        [HttpGet]
        public IEnumerable<QuestionVideo> GetQuestionVideos()
        {
            return _context.QuestionVideos;
        }

        // GET: api/QuestionVideos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionVideo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionVideo = await _context.QuestionVideos.SingleOrDefaultAsync(m => m.Id == id);

            if (questionVideo == null)
            {
                return NotFound();
            }

            return Ok(questionVideo);
        }

        // PUT: api/QuestionVideos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionVideo([FromRoute] int id, [FromBody] QuestionVideo questionVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionVideo.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionVideo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionVideoExists(id))
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

        // POST: api/QuestionVideos
        [HttpPost]
        public async Task<IActionResult> PostQuestionVideo([FromBody] QuestionVideo questionVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionVideos.Add(questionVideo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionVideo", new { id = questionVideo.Id }, questionVideo);
        }

        // DELETE: api/QuestionVideos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionVideo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionVideo = await _context.QuestionVideos.SingleOrDefaultAsync(m => m.Id == id);
            if (questionVideo == null)
            {
                return NotFound();
            }

            _context.QuestionVideos.Remove(questionVideo);
            await _context.SaveChangesAsync();

            return Ok(questionVideo);
        }

        private bool QuestionVideoExists(int id)
        {
            return _context.QuestionVideos.Any(e => e.Id == id);
        }
    }
}