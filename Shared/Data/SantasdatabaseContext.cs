using BlazorApp1santa.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1santa.Server.Data
{
    public class SantasdatabaseContext : DbContext
    {
        public DbSet<Person> Persons {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
            "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "santasdatabase");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Person>()
                .ToContainer("Persons")
                .HasPartitionKey(e => e.Id);
        }
    }
}
