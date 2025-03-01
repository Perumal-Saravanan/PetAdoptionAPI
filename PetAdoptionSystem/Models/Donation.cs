using System;

namespace PetAdoptionSystem.Models
{
    public class Donation
    {
        public int DonationId { get; set; }  // Primary key
        public int UserId { get; set; }  // Foreign key to User
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public string Purpose { get; set; }  // E.g., "Supporting Animal Welfare"

        // Navigation property
        public User User { get; set; }
    }

}
