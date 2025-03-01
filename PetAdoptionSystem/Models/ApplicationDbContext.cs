using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<AdoptionHistory> AdoptionHistories { get; set; }

        // Optional: Configure relationships and key constraints (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the primary key and relationships explicitly (if needed)
            modelBuilder.Entity<AdoptionRequest>()
                .HasKey(ar => ar.RequestId);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.User)
                .WithMany()
                .HasForeignKey(ar => ar.UserId);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Pet)
                .WithMany()
                .HasForeignKey(ar => ar.PetId);

            modelBuilder.Entity<AdoptionHistory>()
                 .HasKey(ah => ah.HistoryId);

            // You can configure other relationships here similarly
        }
    }
}
