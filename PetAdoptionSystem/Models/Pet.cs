namespace PetAdoptionSystem.Models
{
    public class Pet
    {
        public int PetId { get; set; } //Primary Key
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; } // Available / Adopted
    }


}
