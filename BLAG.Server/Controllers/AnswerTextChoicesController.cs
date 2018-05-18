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
    [Route("api/AnswerTextChoices")]
    public class AnswerTextChoicesController : Controller
    {
        private readonly BlagContext _context;

        public AnswerTextChoicesController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/AnswerTextChoices
        [HttpGet]
        public IEnumerable<AnswerTextChoice> GetAnswerTextChoices()
        {
            return _context.AnswerTextChoices;
        }

        // GET: api/AnswerTextChoices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerTextChoice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerTextChoice = await _context.AnswerTextChoices.SingleOrDefaultAsync(m => m.Id == id);

            if (answerTextChoice == null)
            {
                return NotFound();
            }

            return Ok(answerTextChoice);
        }

        // PUT: api/AnswerTextChoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerTextChoice([FromRoute] int id, [FromBody] AnswerTextChoice answerTextChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerTextChoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerTextChoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerTextChoiceExists(id))
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

        // POST: api/AnswerTextChoices
        [HttpPost]
        public async Task<IActionResult> PostAnswerTextChoice([FromBody] AnswerTextChoice answerTextChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AnswerTextChoices.Add(answerTextChoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerTextChoice", new { id = answerTextChoice.Id }, answerTextChoice);
        }

        // DELETE: api/AnswerTextChoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerTextChoice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerTextChoice = await _context.AnswerTextChoices.SingleOrDefaultAsync(m => m.Id == id);
            if (answerTextChoice == null)
            {
                return NotFound();
            }

            _context.AnswerTextChoices.Remove(answerTextChoice);
            await _context.SaveChangesAsync();

            return Ok(answerTextChoice);
        }

        private bool AnswerTextChoiceExists(int id)
        {
            return _context.AnswerTextChoices.Any(e => e.Id == id);
        }
    }
}