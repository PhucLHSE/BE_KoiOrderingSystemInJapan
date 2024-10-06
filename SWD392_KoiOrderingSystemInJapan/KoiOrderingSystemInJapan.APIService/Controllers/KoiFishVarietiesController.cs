using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiFishVarietiesController : ControllerBase
    {
        private readonly KoiOrderingSystemInJapanContext _context;

        public KoiFishVarietiesController(KoiOrderingSystemInJapanContext context)
        {
            _context = context;
        }

        // GET: api/KoiFishVarieties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KoiFishVariety>>> GetKoiFishVarieties()
        {
            return await _context.KoiFishVarieties.ToListAsync();
        }

        // GET: api/KoiFishVarieties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KoiFishVariety>> GetKoiFishVariety(int id)
        {
            var koiFishVariety = await _context.KoiFishVarieties.FindAsync(id);

            if (koiFishVariety == null)
            {
                return NotFound();
            }

            return koiFishVariety;
        }

        // PUT: api/KoiFishVarieties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKoiFishVariety(int id, KoiFishVariety koiFishVariety)
        {
            if (id != koiFishVariety.KoiFishVarietyId)
            {
                return BadRequest();
            }

            _context.Entry(koiFishVariety).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiFishVarietyExists(id))
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

        // POST: api/KoiFishVarieties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KoiFishVariety>> PostKoiFishVariety(KoiFishVariety koiFishVariety)
        {
            _context.KoiFishVarieties.Add(koiFishVariety);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKoiFishVariety", new { id = koiFishVariety.KoiFishVarietyId }, koiFishVariety);
        }

        // DELETE: api/KoiFishVarieties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoiFishVariety(int id)
        {
            var koiFishVariety = await _context.KoiFishVarieties.FindAsync(id);
            if (koiFishVariety == null)
            {
                return NotFound();
            }

            _context.KoiFishVarieties.Remove(koiFishVariety);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KoiFishVarietyExists(int id)
        {
            return _context.KoiFishVarieties.Any(e => e.KoiFishVarietyId == id);
        }
    }
}
