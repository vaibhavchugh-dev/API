using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnFlow.CoreAPI.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rwaAPI.Data;
using rwaAPI.Data.Models;
using rwaAPI.Data.Repositories;

namespace rwaAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ownersController : ApiBaseController
    {
        private readonly rwaAPIContext _context;
        private readonly IownerRespository _ownerRespository;

        public ownersController(rwaAPIContext context, IownerRespository objownerRespository)
        {
            _context = context;
            _ownerRespository = objownerRespository;
        }

        // GET: api/owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<owners>>> Getowners()
        {
            return await _context.owners.ToListAsync();
        }

        // GET: api/owners/5
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

        // PUT: api/owners/5
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

        // POST: api/owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<owners>> Postowners(owners owners)
        {
            _context.owners.Add(owners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getowners", new { id = owners.ownerid }, owners);
        }

        [HttpPost]
        public IActionResult Saveowner([FromBody] owners Owners)
        {
            var result = _ownerRespository.Saveowner(Owners);
            if (result == null)
            {
                return NotFound();
            }
            return CreatedAtAction("Getowners", new { id = Owners.ownerid }, Owners);
        }


        [HttpGet]
        public IActionResult GetOwnerList()
        {
            var objowners = _ownerRespository.Getowner();
            
           return Ok( objowners);
        }

        // DELETE: api/owners/5
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
