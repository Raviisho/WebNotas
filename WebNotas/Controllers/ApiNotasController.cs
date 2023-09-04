using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNotas.Models;

namespace WebNotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNotasController : ControllerBase
    {
        private readonly WebNotasContext _context;

        public ApiNotasController(WebNotasContext context)
        {
            _context = context;
        }

        // GET: api/ApiNotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetNotas()
        {
          if (_context.Notas == null)
          {
              return NotFound();
          }
            return await _context.Notas.ToListAsync();
        }

        // GET: api/ApiNotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nota>> GetNota(int id)
        {
          if (_context.Notas == null)
          {
              return NotFound();
          }
            var nota = await _context.Notas.FindAsync(id);

            if (nota == null)
            {
                return NotFound();
            }

            return nota;
        }

        // PUT: api/ApiNotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, Nota nota)
        {
            if (id != nota.Id)
            {
                return BadRequest();
            }

            _context.Entry(nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(id))
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

        // POST: api/ApiNotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nota>> PostNota(Nota nota)
        {
          if (_context.Notas == null)
          {
              return Problem("Entity set 'WebNotasContext.Notas'  is null.");
          }
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNota", new { id = nota.Id }, nota);
        }

        // DELETE: api/ApiNotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            if (_context.Notas == null)
            {
                return NotFound();
            }
            var nota = await _context.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaExists(int id)
        {
            return (_context.Notas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
