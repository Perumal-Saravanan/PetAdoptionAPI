using System;

namespace PetAdoptionSystem.Models
{
    public class AdoptionRequest
    {
        // Explicitly defining the primary key for AdoptionRequest
        public int RequestId { get; set; }  // Primary key for this entity
        public int UserId { get; set; }
        public int PetId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // Pending / Approved / Denied

        // Navigation properties (used for relationships)
        public User User { get; set; }
        public Pet Pet { get; set; }
    }
}
