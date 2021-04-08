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
        public DbSet<Animal> Animalss { get; set; }
        public DbSet<AnimalPlace> AnimalPlacess { get; set; }
        public DbSet<AnimalType> Typess { get; set; }
        public DbSet<Employee> Employeess { get; set; }
        public DbSet<Equipment> Equipmentss { get; set; }
        public DbSet<Feed> Feedss { get; set; }
        public DbSet<Place> Placess { get; set; }
        public DbSet<Process> Processess { get; set; }
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
