using AnimalFarm.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalFarm.Models
{
    public class FarmContext : DbContext
    {
        static public readonly FarmContext _context = new();
        public DbSet<Species> Specieses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<AnimalPlace> AnimalPlaces { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EmployeeProcess> EmployeeProcesses { get; set; }
        public DbSet<AnimalPlaceProcess> AnimalPlaceProcesses { get; set; }
        public DbSet<FeedProcess> FeedProcesses { get; set; }
        public DbSet<EquipmentProcess> EquipmentProcesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Database=AnimalFarm;Trusted_Connection=True;");
        }
    }
}
