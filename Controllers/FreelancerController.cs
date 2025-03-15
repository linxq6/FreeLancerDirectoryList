using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FreeLancerDirectoryList.Controllers
{
    [Route("api/freelancers")]
    [ApiController]
    public class FreelancerController : Controller
    {
        private readonly FreelancerDbContext _context;

        public FreelancerController(FreelancerDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFreelancer([FromBody] Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFreelancer), new { id = freelancer.Id }, freelancer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancer(int id)
        {
            var freelancer = await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);
            return freelancer != null ? Ok(freelancer) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetFreelancers([FromQuery] string search)
        {
            var freelancers = await _context.Freelancers
                .Where(f => string.IsNullOrEmpty(search) || f.Username.Contains(search) || f.Email.Contains(search))
                .ToListAsync();
            return Ok(freelancers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancer(int id, [FromBody] Freelancer freelancer)
        {
            var existing = await _context.Freelancers.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Username = freelancer.Username;
            existing.Email = freelancer.Email;
            existing.PhoneNumber = freelancer.PhoneNumber;
            existing.Skillsets = freelancer.Skillsets;
            existing.Hobbies = freelancer.Hobbies;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null) return NotFound();

            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/archive")]
        public async Task<IActionResult> ArchiveFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null) return NotFound();

            freelancer.IsArchived = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/unarchive")]
        public async Task<IActionResult> UnarchiveFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null) return NotFound();

            freelancer.IsArchived = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
