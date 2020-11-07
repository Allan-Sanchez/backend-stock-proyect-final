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
    public class BuysController : ControllerBase
    {
        private readonly ProyectContext _context;

        public BuysController(ProyectContext context)
        {
            _context = context;
        }

        // GET: api/Buys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buy>>> GetBuy()
        {
            return await _context.Buy.ToListAsync();
        }

        // GET: api/Buys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buy>> GetBuy(int id)
        {
            var buy = await _context.Buy.FindAsync(id);

            if (buy == null)
            {
                return NotFound();
            }

            return buy;
        }

        // PUT: api/Buys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuy(int id, Buy buy)
        {
            if (id != buy.BuyId)
            {
                return BadRequest();
            }

            _context.Entry(buy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyExists(id))
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

        // POST: api/Buys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Buy>> PostBuy(Buy buy)
        {
            _context.Buy.Add(buy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuy", new { id = buy.BuyId }, buy);
        }

        // DELETE: api/Buys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Buy>> DeleteBuy(int id)
        {
            var buy = await _context.Buy.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }

            _context.Buy.Remove(buy);
            await _context.SaveChangesAsync();

            return buy;
        }

        private bool BuyExists(int id)
        {
            return _context.Buy.Any(e => e.BuyId == id);
        }
    }
}
