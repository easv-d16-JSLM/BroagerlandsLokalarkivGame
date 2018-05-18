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
    [Route("api/AnswerNumbers")]
    public class AnswerNumbersController : Controller
    {
        private readonly BlagContext _context;

        public AnswerNumbersController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/AnswerNumbers
        [HttpGet]
        public IEnumerable<AnswerNumber> GetAnswerNumbers()
        {
            return _context.AnswerNumbers;
        }

        // GET: api/AnswerNumbers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerNumber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerNumber = await _context.AnswerNumbers.SingleOrDefaultAsync(m => m.Id == id);

            if (answerNumber == null)
            {
                return NotFound();
            }

            return Ok(answerNumber);
        }

        // PUT: api/AnswerNumbers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerNumber([FromRoute] int id, [FromBody] AnswerNumber answerNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerNumber.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerNumberExists(id))
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

        // POST: api/AnswerNumbers
        [HttpPost]
        public async Task<IActionResult> PostAnswerNumber([FromBody] AnswerNumber answerNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AnswerNumbers.Add(answerNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerNumber", new { id = answerNumber.Id }, answerNumber);
        }

        // DELETE: api/AnswerNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerNumber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerNumber = await _context.AnswerNumbers.SingleOrDefaultAsync(m => m.Id == id);
            if (answerNumber == null)
            {
                return NotFound();
            }

            _context.AnswerNumbers.Remove(answerNumber);
            await _context.SaveChangesAsync();

            return Ok(answerNumber);
        }

        private bool AnswerNumberExists(int id)
        {
            return _context.AnswerNumbers.Any(e => e.Id == id);
        }
    }
}