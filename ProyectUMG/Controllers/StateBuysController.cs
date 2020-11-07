using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectUMG.Models;

namespace ProyectUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateBuysController : ControllerBase
    {
        private readonly ProyectContext _context;

        public StateBuysController(ProyectContext context)
        {
            _context = context;
        }

        // GET: api/StateBuys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateBuy>>> GetStateBuy()
        {
            var state = await _context.StateBuy.Include(p => p.Buys).ToListAsync();

            if (state == null)
            {
                return NotFound();
            }

            return state;
            //return await _context.StateBuy.ToListAsync();
        }

        // GET: api/StateBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateBuy>> GetStateBuy(int id)
        {
            var stateBuy = await _context.StateBuy.FindAsync(id);

            if (stateBuy == null)
            {
                return NotFound();
            }

            return stateBuy;
        }

        // PUT: api/StateBuys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateBuy(int id, StateBuy stateBuy)
        {
            if (id != stateBuy.StateBuyId)
            {
                return BadRequest();
            }

            _context.Entry(stateBuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateBuyExists(id))
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

        // POST: api/StateBuys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StateBuy>> PostStateBuy(StateBuy stateBuy)
        {
            _context.StateBuy.Add(stateBuy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStateBuy", new { id = stateBuy.StateBuyId }, stateBuy);
        }

        // DELETE: api/StateBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StateBuy>> DeleteStateBuy(int id)
        {
            var stateBuy = await _context.StateBuy.FindAsync(id);
            if (stateBuy == null)
            {
                return NotFound();
            }

            _context.StateBuy.Remove(stateBuy);
            await _context.SaveChangesAsync();

            return stateBuy;
        }

        private bool StateBuyExists(int id)
        {
            return _context.StateBuy.Any(e => e.StateBuyId == id);
        }
    }
}
