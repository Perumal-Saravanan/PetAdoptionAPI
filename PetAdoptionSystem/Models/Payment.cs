using System;

namespace PetAdoptionSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }  // Primary key
        public int UserId { get; set; }  // Foreign key to User
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }  // E.g., Credit Card, PayPal

        // Navigation property
        public User User { get; set; }
    }

}
