using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xassee.Training.CRM.Api.Models;

namespace Xassee.Training.CRM.Api.Controllers
{
    [Produces("application/json")]
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        private readonly XasseeTrainingCRMApiContext _context;

        public FeedbackController(XasseeTrainingCRMApiContext context)
        {
            _context = context;
        }

        // GET: api/Feedback
        [HttpGet]
        public IEnumerable<Feedback> GetFeedback()
        {
            return _context.Feedback;
        }

        // GET: api/Feedback/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedback([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = await _context.Feedback.SingleOrDefaultAsync(m => m.FeedbackId == id);

            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/Feedback/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback([FromRoute] int id, [FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedback
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedback", new { id = feedback.FeedbackId }, feedback);
        }

        // DELETE: api/Feedback/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = await _context.Feedback.SingleOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedback.Remove(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.FeedbackId == id);
        }
    }
}