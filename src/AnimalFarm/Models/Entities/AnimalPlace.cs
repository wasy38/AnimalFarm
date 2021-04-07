using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record AnimalPlace
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public int AnimalId { get; set; }
        public IQueryable<Animal> Animals { get; set; }
        public int PlaceId { get; set; }
        public IQueryable<Place> Places { get; set; }
        public DateTime Occupancy { get; set; }
    }
}
