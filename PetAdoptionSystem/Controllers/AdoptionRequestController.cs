using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Models;
using System.Threading.Tasks;

namespace PetAdoptionSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create an adoption request
        [HttpPost("create")]
        public async Task<IActionResult> CreateAdoptionRequest([FromBody] AdoptionRequest request)
        {
            _context.AdoptionRequests.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        // Get all adoption requests
        [HttpGet("all")]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _context.AdoptionRequests.ToListAsync();
            return Ok(requests);
        }
    }

}



