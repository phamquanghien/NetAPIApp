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
    public class DaiLyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DaiLyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DaiLy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaiLy>>> GetDaiLy()
        {
          if (_context.DaiLy == null)
          {
              return NotFound();
          }
            return await _context.DaiLy.ToListAsync();
        }

        // GET: api/DaiLy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DaiLy>> GetDaiLy(string id)
        {
          if (_context.DaiLy == null)
          {
              return NotFound();
          }
            var daiLy = await _context.DaiLy.FindAsync(id);

            if (daiLy == null)
            {
                return NotFound();
            }

            return daiLy;
        }

        // PUT: api/DaiLy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaiLy(string id, DaiLy daiLy)
        {
            if (id != daiLy.MaDaiLy)
            {
                return BadRequest();
            }

            _context.Entry(daiLy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaiLyExists(id))
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

        // POST: api/DaiLy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DaiLy>> PostDaiLy(DaiLy daiLy)
        {
          if (_context.DaiLy == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DaiLy'  is null.");
          }
            _context.DaiLy.Add(daiLy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DaiLyExists(daiLy.MaDaiLy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDaiLy", new { id = daiLy.MaDaiLy }, daiLy);
        }

        // DELETE: api/DaiLy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaiLy(string id)
        {
            if (_context.DaiLy == null)
            {
                return NotFound();
            }
            var daiLy = await _context.DaiLy.FindAsync(id);
            if (daiLy == null)
            {
                return NotFound();
            }

            _context.DaiLy.Remove(daiLy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DaiLyExists(string id)
        {
            return (_context.DaiLy?.Any(e => e.MaDaiLy == id)).GetValueOrDefault();
        }
    }
}
