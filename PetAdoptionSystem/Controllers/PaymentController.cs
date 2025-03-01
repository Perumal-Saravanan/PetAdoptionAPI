using Microsoft.AspNetCore.Mvc;
using PetAdoptionSystem.Models;
using System.Threading.Tasks;

namespace PetAdoptionSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new payment
        [HttpPost("payment")]
        public async Task<IActionResult> MakePayment([FromBody] Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);
        }

        // Create a new donation
        [HttpPost("donation")]
        public async Task<IActionResult> MakeDonation([FromBody] Donation donation)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();
            return Ok(donation);
        }
    }

}
