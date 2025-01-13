using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarieSkema.Models;

namespace MarieSkema.Controllers
{
    [Route("api/[controller]")] // Route for the API
    [ApiController] // Marks this as an API controller
    public class LaererController : ControllerBase
    {
        private readonly SkemaDbContext _context;

        public LaererController(SkemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Laerer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laerer>>> GetLaerers()
        {
            return await _context.Laerer.ToListAsync();
        }

        // GET: api/Laerer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Laerer>> GetLaerer(int id)
        {
            var laerer = await _context.Laerer.FindAsync(id);

            if (laerer == null)
            {
                return NotFound();
            }

            return laerer;
        }

        // POST: api/Laerer
        [HttpPost]
        public async Task<ActionResult<Laerer>> PostLaerer(Laerer laerer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Laerer.Add(laerer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLaerer), new { id = laerer.LaererId }, laerer);
        }

        // PUT: api/Laerer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaerer(int id, Laerer laerer)
        {
            if (id != laerer.LaererId)
            {
                return BadRequest();
            }

            _context.Entry(laerer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaererExists(id))
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

        // DELETE: api/Laerer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaerer(int id)
        {
            var laerer = await _context.Laerer.FindAsync(id);
            if (laerer == null)
            {
                return NotFound();
            }

            _context.Laerer.Remove(laerer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaererExists(int id)
        {
            return _context.Laerer.Any(e => e.LaererId == id);
        }
    }
}