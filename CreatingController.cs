using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASSESSEMENT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }

    // Controllers/PropertiesController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostProperty(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return Ok(property);
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _context.Properties.Include(p => p.Seller).ToListAsync();
            return Ok(properties);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _context.Entry(property).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterProperties([FromQuery] string place, [FromQuery] int? bedrooms)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(p => p.Place.Contains(place));
            }

            if (bedrooms.HasValue)
            {
                query = query.Where(p => p.Bedrooms == bedrooms.Value);
            }

            var properties = await query.ToListAsync();
            return Ok(properties);
        }
    }
}
