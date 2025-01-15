using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarieSkema.Models;
using MarieSkema.Mappers;
using MarieSkema.DTO;

namespace MarieSkema.Controllers
{
    [Route("api/[controller]")] // Route for the API
    [ApiController] // Marks this as an API controller
    public class FagController : ControllerBase
    {
        private readonly SkemaDbContext _context;

        public FagController(SkemaDbContext context)
        {
            _context = context;
        }

        // GET: api/Fag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fag>>> GetFags()
        {
            return await _context.Fag.ToListAsync();
        }

        // GET: api/Fag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fag>> GetFag(int id)
        {
            var fag = await _context.Fag.FindAsync(id);

            if (fag == null)
            {
                return NotFound();
            }

            var fagDTO = FagMapper.GetFagDTO(fag);

            return Ok(fagDTO);
        }

        // POST: api/Fag
        [HttpPost]
        public async Task<ActionResult<Fag>> PostFag(FagDTOPost fagDTOPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
              
            var fag = FagMapper.PostToFag(fagDTOPost);
            _context.Fag.Add(fag);
            
            try 
            {
                await _context.SaveChangesAsync();
                var fagDTO = FagMapper.GetFagDTO(fag);
                return CreatedAtAction(nameof(GetFag), new { id = fag.FagId }, fagDTO);
            }
            catch (DbUpdateException ex) 
            {
                if (ex.InnerException?.Message.Contains("unique constraint") ?? false)
                {
                    return Conflict("A similar record already exists");
                }
                
                throw;
            }
        }

        // PUT: api/Fag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFag(int id, Fag fag)
        {
            if (id != fag.FagId)
            {
                return BadRequest();
            }

            _context.Entry(fag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FagExists(id))
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

        // DELETE: api/Fag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFag(int id)
        {
            var fag = await _context.Fag.FindAsync(id);
            if (fag == null)
            {
                return NotFound();
            }

            _context.Fag.Remove(fag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FagExists(int id)
        {
            return _context.Fag.Any(e => e.FagId == id);
        }
    }
}