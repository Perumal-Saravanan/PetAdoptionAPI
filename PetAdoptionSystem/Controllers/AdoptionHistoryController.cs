using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdoptionHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get adoption history for a user
        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetAdoptionHistory(int userId)
        {
            var history = await _context.AdoptionRequests
                .Where(ar => ar.UserId == userId && ar.Status == "Approved")
                .ToListAsync();

            return Ok(history);
        }
    }

}
