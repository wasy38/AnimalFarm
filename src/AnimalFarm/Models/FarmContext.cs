using AnimalFarm.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models
{
    public class FarmContext: DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalPlace> AnimalPlaces { get; set; }
        public DbSet<AnimalType> Types { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Process> Processes { get; set; }
        public FarmContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"ConnectionString": "Data Source=(local)\\SQLEXPRESS; Database=LabsWebAppDB; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;",
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }

    }
}
