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
    [Route("api/QuestionAudios")]
    public class QuestionAudiosController : Controller
    {
        private readonly BlagContext _context;

        public QuestionAudiosController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/QuestionAudios
        [HttpGet]
        public IEnumerable<QuestionAudio> GetQuestionAudios()
        {
            return _context.QuestionAudios;
        }

        // GET: api/QuestionAudios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionAudio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionAudio = await _context.QuestionAudios.SingleOrDefaultAsync(m => m.Id == id);

            if (questionAudio == null)
            {
                return NotFound();
            }

            return Ok(questionAudio);
        }

        // PUT: api/QuestionAudios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionAudio([FromRoute] int id, [FromBody] QuestionAudio questionAudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionAudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionAudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionAudioExists(id))
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

        // POST: api/QuestionAudios
        [HttpPost]
        public async Task<IActionResult> PostQuestionAudio([FromBody] QuestionAudio questionAudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionAudios.Add(questionAudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionAudio", new { id = questionAudio.Id }, questionAudio);
        }

        // DELETE: api/QuestionAudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAudio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionAudio = await _context.QuestionAudios.SingleOrDefaultAsync(m => m.Id == id);
            if (questionAudio == null)
            {
                return NotFound();
            }

            _context.QuestionAudios.Remove(questionAudio);
            await _context.SaveChangesAsync();

            return Ok(questionAudio);
        }

        private bool QuestionAudioExists(int id)
        {
            return _context.QuestionAudios.Any(e => e.Id == id);
        }
    }
}