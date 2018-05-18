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
    [Route("api/AnswerMaps")]
    public class AnswerMapsController : Controller
    {
        private readonly BlagContext _context;

        public AnswerMapsController(BlagContext context)
        {
            _context = context;
        }

        // GET: api/AnswerMaps
        [HttpGet]
        public IEnumerable<AnswerMap> GetAnswerMaps()
        {
            return _context.AnswerMaps;
        }

        // GET: api/AnswerMaps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerMap([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerMap = await _context.AnswerMaps.SingleOrDefaultAsync(m => m.Id == id);

            if (answerMap == null)
            {
                return NotFound();
            }

            return Ok(answerMap);
        }

        // PUT: api/AnswerMaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerMap([FromRoute] int id, [FromBody] AnswerMap answerMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerMapExists(id))
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

        // POST: api/AnswerMaps
        [HttpPost]
        public async Task<IActionResult> PostAnswerMap([FromBody] AnswerMap answerMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AnswerMaps.Add(answerMap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerMap", new { id = answerMap.Id }, answerMap);
        }

        // DELETE: api/AnswerMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerMap([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerMap = await _context.AnswerMaps.SingleOrDefaultAsync(m => m.Id == id);
            if (answerMap == null)
            {
                return NotFound();
            }

            _context.AnswerMaps.Remove(answerMap);
            await _context.SaveChangesAsync();

            return Ok(answerMap);
        }

        private bool AnswerMapExists(int id)
        {
            return _context.AnswerMaps.Any(e => e.Id == id);
        }
    }
}