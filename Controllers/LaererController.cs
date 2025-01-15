using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarieSkema.Models;
using MarieSkema.Mappers;
using MarieSkema.DTO;

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
        public async Task<ActionResult<IEnumerable<LaererDTO>>> GetLaerers()
        {
            var laerere = await _context.Laerer.ToListAsync();
            return laerere.Select(l => LaererMapper.laererDTOMapper(l)).ToList();
        }

        // GET: api/Laerer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaererDTO>> GetLaerer(int id)
        {
            var laerer = await _context.Laerer.FindAsync(id);

            if (laerer == null)
            {
                return NotFound();
            }

            return LaererMapper.laererDTOMapper(laerer);
        }

        // POST: api/Laerer
        [HttpPost]
        public async Task<ActionResult<LaererDTO>> PostLaerer(LaererDTO laererDTO)
        {
            var laerer = LaererMapper.LæarerPostMapper(laererDTO);
            _context.Laerer.Add(laerer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetLaerer),
                new { id = laerer.LaererId }, 
                LaererMapper.laererDTOMapper(laerer));
        }

        // PUT: api/Laerer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaerer(int id, LaererDTO laererDTO)
        {
            if (id != laererDTO.LaererId)
            {
                return BadRequest();
            }

            var laerer = LaererMapper.LæarerPostMapper(laererDTO);
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