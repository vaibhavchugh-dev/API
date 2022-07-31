using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class towersController : ApiBaseController
    {
        private readonly rwaAPIContext _context;
        private readonly ItowerRespository _towerRepository;
        public readonly IownerRespository _ownerRespository;
        public towersController(rwaAPIContext context, ItowerRespository objtowerRepository)
        {
            _context = context;
            _towerRepository = objtowerRepository;
        }

        // GET: api/towers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<towers>>> Gettowers()
        {
            return await _context.towers.ToListAsync();
        }

        // GET: api/towers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<towers>> Gettowers(int id)
        {
            var towers = await _context.towers.FindAsync(id);

            if (towers == null)
            {
                return NotFound();
            }

            return towers;
        }

        // PUT: api/towers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttowers(int id, towers towers)
        {
            if (id != towers.id)
            {
                return BadRequest();
            }

            _context.Entry(towers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!towersExists(id))
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

        // POST: api/towers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<towers>> Posttowers(towers towers)
        {
            _context.towers.Add(towers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettowers", new { id = towers.id }, towers);
        }



        [HttpPost]
        public IActionResult SaveTower([FromBody] towers Towers)
        {
            var result = _towerRepository.Savetower(Towers);
            if (result == null)
            {
                return NotFound();
            }
            return CreatedAtAction("Gettowers", new { id = Towers.id }, Towers);
        }

        [HttpPost]
        public IActionResult UpdateTower([FromBody] towers Towers)
        {
            var result = _towerRepository.UpdateTower(Towers);
            if (result == null)
            {
                return NotFound();
            }
            return CreatedAtAction("Gettowers", new { id = Towers.id }, Towers);
        }


        // DELETE: api/towers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetowers(int id)
        {
            var towers = await _context.towers.FindAsync(id);
            if (towers == null)
            {
                return NotFound();
            }

            _context.towers.Remove(towers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool towersExists(int id)
        {
            return _context.towers.Any(e => e.id == id);
        }
    }
}
