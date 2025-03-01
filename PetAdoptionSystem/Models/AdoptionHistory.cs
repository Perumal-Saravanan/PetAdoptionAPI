using System;

namespace PetAdoptionSystem.Models
{
    public class AdoptionHistory
    {
        public int HistoryId { get; set; }  // Primary key
        public int UserId { get; set; }  // Foreign key to User
        public int PetId { get; set; }  // Foreign key to Pet
        public DateTime AdoptionDate { get; set; }
        public string Status { get; set; }  // Adopted, Approved

        // Navigation properties
        public User User { get; set; }
        public Pet Pet { get; set; }
    }

}
