using HeroManagerAPI.Data;
using HeroManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroManagerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperPowerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuperPowerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All SuperPowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperPower>>> GetSuperPowers()
        {
            return await _context.SuperPowers.ToListAsync();
        }

        // Get SuperPower By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperPower>> GetSuperPowerById(int id)
        {
            var superPower = await _context.SuperPowers.FindAsync(id);

            if (superPower == null)
            {
                return NotFound();
            }

            return superPower;
        }
    }
}
