﻿namespace PetAdoptionSystem.Models
{
    public class User
    {
        public int UserId { get; set; } //Primary Key
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; } // Admin/User
    }

}
