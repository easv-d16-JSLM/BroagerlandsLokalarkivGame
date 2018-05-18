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
    [Route("api/QuestionTexts")]
    public class QuestionTextsController : Controller
    {
        private readonly BlagContext _context;

        public QuestionTextsController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/QuestionTexts
        [HttpGet]
        public IEnumerable<QuestionText> GetQuestionTexts()
        {
            return _context.QuestionTexts;
        }

        // GET: api/QuestionTexts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionText([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionText = await _context.QuestionTexts.SingleOrDefaultAsync(m => m.Id == id);

            if (questionText == null)
            {
                return NotFound();
            }

            return Ok(questionText);
        }

        // PUT: api/QuestionTexts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionText([FromRoute] int id, [FromBody] QuestionText questionText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionText.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTextExists(id))
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

        // POST: api/QuestionTexts
        [HttpPost]
        public async Task<IActionResult> PostQuestionText([FromBody] QuestionText questionText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionTexts.Add(questionText);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionText", new { id = questionText.Id }, questionText);
        }

        // DELETE: api/QuestionTexts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionText([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionText = await _context.QuestionTexts.SingleOrDefaultAsync(m => m.Id == id);
            if (questionText == null)
            {
                return NotFound();
            }

            _context.QuestionTexts.Remove(questionText);
            await _context.SaveChangesAsync();

            return Ok(questionText);
        }

        private bool QuestionTextExists(int id)
        {
            return _context.QuestionTexts.Any(e => e.Id == id);
        }
    }
}