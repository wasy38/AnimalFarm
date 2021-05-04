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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .HasMany(c => c.Processes)
                .WithMany(d => d.Equipments)
                .UsingEntity<EquipmentProcess>(
                    j => j
                        .HasOne(pt => pt.Process)
                        .WithMany(p => p.EquipmentPocesses)
                        .HasForeignKey(pt => pt.EquipmentId),
                    j => j.HasOne(pt => pt.Equipment).WithMany(p => p.EquipmentProcesses).HasForeignKey(pt => pt.ProcessId),
                    j =>
                    {
                        j.HasKey(t => new { t.EquipmentId, t.ProcessId });
                    });

            modelBuilder.Entity<Feed>()
                .HasMany(c => c.Processes)
                .WithMany(d => d.Feeds)
                .UsingEntity<FeedProcess>(
                    j => j
                        .HasOne(pt => pt.Process)
                        .WithMany(p => p.FeedPocesses)
                        .HasForeignKey(pt => pt.FeedId),
                    j => j.HasOne(pt => pt.Feed).WithMany(p =>p.FeedPocesses).HasForeignKey(pt => pt.ProcessId),
                    j =>
                    {
                        j.HasKey(t => new { t.FeedId, t.ProcessId });
                    });

            modelBuilder.Entity<AnimalPlace>()
                .HasMany(c => c.Processes)
                .WithMany(d => d.AnimalPlaces)
                .UsingEntity<AnimalPlaceProcess>(
                    j => j
                        .HasOne(pt => pt.Process)
                        .WithMany(p => p.AnimalPlaceProcesses)
                        .HasForeignKey(pt => pt.AnimalPlaceId),
                    j => j.HasOne(pt => pt.AnimalPlace).WithMany(p => p.AnimalPlaceProcesses).HasForeignKey(pt => pt.ProcessId),
                    j =>
                    {
                        j.HasKey(t => new { t.AnimalPlaceId, t.ProcessId });
                    });
           
            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Processes)
                .WithMany(d => d.Employees)
                .UsingEntity<EmployeeProcess>(
                    j => j
                        .HasOne(pt => pt.Process)
                        .WithMany(p=>p.EmployeePocesses)
                        .HasForeignKey(pt=>pt.EmployeeId),
                    j => j.HasOne(pt=>pt.Employee).WithMany(p=>p.EmployeePocesses).HasForeignKey(pt=>pt.ProcessId),
                    j =>
                    {
                        j.HasKey(t => new { t.EmployeeId, t.ProcessId });
                    }); 
        }
    }
}
