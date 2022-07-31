using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rwaAPI.Data;
using rwaAPI.Data.Models;

namespace rwaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class owners1Controller : ControllerBase
    {
        private readonly rwaAPIContext _context;

        public owners1Controller(rwaAPIContext context)
        {
            _context = context;
        }

        // GET: api/owners1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<owners>>> Getowners()
        {
            return await _context.owners.ToListAsync();
        }

        // GET: api/owners1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<owners>> Getowners(int id)
        {
            var owners = await _context.owners.FindAsync(id);

            if (owners == null)
            {
                return NotFound();
            }

            return owners;
        }

        // PUT: api/owners1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putowners(int id, owners owners)
        {
            if (id != owners.ownerid)
            {
                return BadRequest();
            }

            _context.Entry(owners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ownersExists(id))
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

        // POST: api/owners1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<owners>> Postowners(owners owners)
        {
            _context.owners.Add(owners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getowners", new { id = owners.ownerid }, owners);
        }

        // DELETE: api/owners1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteowners(int id)
        {
            var owners = await _context.owners.FindAsync(id);
            if (owners == null)
            {
                return NotFound();
            }

            _context.owners.Remove(owners);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ownersExists(int id)
        {
            return _context.owners.Any(e => e.ownerid == id);
        }
    }
}
