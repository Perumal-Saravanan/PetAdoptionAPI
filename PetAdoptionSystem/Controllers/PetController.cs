using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace PetAdoptionSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPet([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest("Pet is null.");
            }

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok("Pet added successfully.");
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
        {
            var pets = await _context.Pets.Where(p => p.Status == "Available").ToListAsync();
            return Ok(pets);
        }

        [HttpPost("adopt")]
        [Authorize]
        public async Task<IActionResult> RequestAdoption([FromBody] AdoptionRequest request)
        {
            if (request == null)
            {
                return BadRequest("AdoptionRequest is null.");
            }

            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
            request.UserId = int.Parse(userId);
            request.RequestDate = DateTime.UtcNow;
            request.Status = "Pending";

            _context.AdoptionRequests.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Adoption request submitted.");
        }
    }

}



