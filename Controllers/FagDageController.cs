using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarieSkema.Models;

namespace MarieSkema.Controllers
{
    [Route("api/[controller]")] // Route for the API
    [ApiController] // Marks this as an API controller
    public class FagDageController : ControllerBase
    {
        private readonly SkemaDbContext _context;

        public FagDageController(SkemaDbContext context)
        {
            _context = context;
        }

        // GET: api/FagDage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FagDage>>> GetFagDages()
        {
            return await _context.FagDages.ToListAsync();
        }

        // GET: api/FagDage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FagDage>> GetFagDage(int id)
        {
            var fagDage = await _context.FagDages.FindAsync(id);

            if (fagDage == null)
            {
                return NotFound();
            }

            return fagDage;
        }

        // POST: api/FagDage
        [HttpPost]
        public async Task<ActionResult<FagDage>> PostFagDage(FagDage fagDage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FagDages.Add(fagDage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFagDage), new { id = fagDage.FagDageId }, fagDage);
        }

        // PUT: api/FagDage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFagDage(int id, FagDage fagDage)
        {
            if (id != fagDage.FagDageId)
            {
                return BadRequest();
            }

            _context.Entry(fagDage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FagDageExists(id))
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

        // DELETE: api/FagDage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFagDage(int id)
        {
            var fagDage = await _context.FagDages.FindAsync(id);
            if (fagDage == null)
            {
                return NotFound();
            }

            _context.FagDages.Remove(fagDage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FagDageExists(int id)
        {
            return _context.FagDages.Any(e => e.FagDageId == id);
        }
    }
}