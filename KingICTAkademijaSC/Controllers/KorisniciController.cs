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
    [Route("dummyjson.com/users")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly KorisniciContext _context;

        public KorisniciController(KorisniciContext context)
        {
            _context = context;
        }

        // GET: api/Korisnici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisnici()
        {
            return await _context.Korisnici.ToListAsync();
        }

        // GET: api/Korisnici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(long id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        // PUT: api/Korisnici/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorisnik(long id, Korisnik korisnik)
        {
            if (id != korisnik.Id)
            {
                return BadRequest();
            }

            _context.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisnici
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik korisnik)
        {
            _context.Korisnici.Add(korisnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisnik", new { id = korisnik.Id }, korisnik);
        }

        // DELETE: api/Korisnici/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(long id)
        {
            var korisnik = await _context.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisnici.Remove(korisnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisnikExists(long id)
        {
            return _context.Korisnici.Any(e => e.Id == id);
        }
    }
}
