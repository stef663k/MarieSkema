using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarieSkema.Models;
using MarieSkema.Mappers;
using MarieSkema.DTO;

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
        public async Task<ActionResult<IEnumerable<FagDdagDTO>>> GetFagDages()
        {
            try
            {
                var fagDages = await _context.FagDages.ToListAsync();
                return Ok(fagDages.Select(f => FagDagMapper.fagDdagDTOGETMapper(f)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/FagDage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FagDdagDTO>> GetFagDage(int id)
        {
            try
            {
                var fagDage = await _context.FagDages.FindAsync(id);
                if (fagDage == null)
                {
                    return NotFound();
                }
                return Ok(FagDagMapper.fagDdagDTOGETMapper(fagDage));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

         // POST: api/FagDage
        [HttpPost]
        public async Task<ActionResult<FagDdagDTO>> PostFagDage(FagDdagDTOPost fagDageDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate FagId and LaererId
                var fagExists = await _context.Fag.AnyAsync(f => f.FagId == fagDageDto.FagId);
                var laererExists = await _context.Laerer.AnyAsync(l => l.LaererId == fagDageDto.LaererId);

                if (!fagExists || !laererExists)
                {
                    return BadRequest("Invalid FagId or LaererId: The specified IDs do not exist.");
                }

                var fagDage = FagDagMapper.fagDdagDTOPOSTMapper(fagDageDto);
                _context.FagDages.Add(fagDage);
                await _context.SaveChangesAsync();

                var resultDto = FagDagMapper.fagDdagDTOGETMapper(fagDage);
                return CreatedAtAction(nameof(GetFagDage), new { id = resultDto.FagDdageId }, resultDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/FagDage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFagDage(int id, FagDdagDTOPost fagDageDto)
        {
            try
            {
                if (id != fagDageDto.FagId && id != fagDageDto.LaererId)
                {
                    return BadRequest();
                }

                var fagDage = FagDagMapper.fagDdagDTOPOSTMapper(fagDageDto);
                fagDage.FagDageId = id;  // Ensure ID is set
                _context.Entry(fagDage).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FagDageExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/FagDage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFagDage(int id)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private bool FagDageExists(int id)
        {
            return _context.FagDages.Any(e => e.FagDageId == id);
        }
    }
}