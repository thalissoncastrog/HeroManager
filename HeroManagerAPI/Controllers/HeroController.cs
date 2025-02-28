using HeroManagerAPI.Data;
using HeroManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroManagerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a Hero
        [HttpPost]
        public async Task<ActionResult<Hero>> CreateHero([FromBody] Hero hero)
        {
            if (_context.Heroes.Any(h => h.HeroName == hero.HeroName))
            {
                return BadRequest("Hero name already exists.");
            }

            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            var createdHero = await _context.Heroes
                                            .Include(h => h.HeroSuperPowers)
                                            .ThenInclude(hsp => hsp.SuperPower)
                                            .FirstOrDefaultAsync(h => h.Id == hero.Id);

            return CreatedAtAction(nameof(GetHeroById), new { id = hero.Id }, hero);
        }

        // Get All Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            return await _context.Heroes.Include(h => h.HeroSuperPowers)
                                        .ThenInclude(hsp => hsp.SuperPower)
                                        .ToListAsync();
        }

        // Get Hero By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var hero = await _context.Heroes
                                     .Include(h => h.HeroSuperPowers)
                                     .ThenInclude(hsp => hsp.SuperPower)
                                     .FirstOrDefaultAsync(h => h.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // Update Hero
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            if (_context.Heroes.Any(h => h.HeroName == hero.HeroName && h.Id != id))
            {
                return BadRequest("Hero name already exists.");
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Heroes.Any(h => h.Id == id))
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

        // Delete Hero
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
