using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KingICTAkademijaSC.Models;

namespace KingICTAkademijaSC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private readonly ProizvodiContext _context;

        public ProizvodiController(ProizvodiContext context)
        {
            _context = context;
        }

        // GET: api/Proizvodi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proizvod>>> GetProizvodi()
        {
            return await _context.Proizvodi.ToListAsync();
        }

        // GET: api/Proizvodi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proizvod>> GetProizvod(long id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);

            if (proizvod == null)
            {
                return NotFound();
            }

            return proizvod;
        }

        // PUT: api/Proizvodi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProizvod(long id, Proizvod proizvod)
        {
            if (id != proizvod.Id)
            {
                return BadRequest();
            }

            _context.Entry(proizvod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
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

        // POST: api/Proizvodi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proizvod>> PostProizvod(Proizvod proizvod)
        {
            _context.Proizvodi.Add(proizvod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProizvod", new { id = proizvod.Id }, proizvod);
        }

        // DELETE: api/Proizvodi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProizvod(long id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            _context.Proizvodi.Remove(proizvod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProizvodExists(long id)
        {
            return _context.Proizvodi.Any(e => e.Id == id);
        }
    }
}
