using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetAPIApp.Data;
using NetAPIApp.Models;

namespace NetAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeThongPhanPhoiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeThongPhanPhoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HeThongPhanPhoi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeThongPhanPhoi>>> GetHeThongPhanPhoi()
        {
          if (_context.HeThongPhanPhoi == null)
          {
              return NotFound();
          }
            return await _context.HeThongPhanPhoi.ToListAsync();
        }

        // GET: api/HeThongPhanPhoi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeThongPhanPhoi>> GetHeThongPhanPhoi(string id)
        {
          if (_context.HeThongPhanPhoi == null)
          {
              return NotFound();
          }
            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);

            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            return heThongPhanPhoi;
        }

        // PUT: api/HeThongPhanPhoi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeThongPhanPhoi(string id, HeThongPhanPhoi heThongPhanPhoi)
        {
            if (id != heThongPhanPhoi.MaHTPP)
            {
                return BadRequest();
            }

            _context.Entry(heThongPhanPhoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeThongPhanPhoiExists(id))
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

        // POST: api/HeThongPhanPhoi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeThongPhanPhoi>> PostHeThongPhanPhoi(HeThongPhanPhoi heThongPhanPhoi)
        {
          if (_context.HeThongPhanPhoi == null)
          {
              return Problem("Entity set 'ApplicationDbContext.HeThongPhanPhoi'  is null.");
          }
            _context.HeThongPhanPhoi.Add(heThongPhanPhoi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HeThongPhanPhoiExists(heThongPhanPhoi.MaHTPP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHeThongPhanPhoi", new { id = heThongPhanPhoi.MaHTPP }, heThongPhanPhoi);
        }

        // DELETE: api/HeThongPhanPhoi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeThongPhanPhoi(string id)
        {
            if (_context.HeThongPhanPhoi == null)
            {
                return NotFound();
            }
            var heThongPhanPhoi = await _context.HeThongPhanPhoi.FindAsync(id);
            if (heThongPhanPhoi == null)
            {
                return NotFound();
            }

            _context.HeThongPhanPhoi.Remove(heThongPhanPhoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeThongPhanPhoiExists(string id)
        {
            return (_context.HeThongPhanPhoi?.Any(e => e.MaHTPP == id)).GetValueOrDefault();
        }
    }
}
