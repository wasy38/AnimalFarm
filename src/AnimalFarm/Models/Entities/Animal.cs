using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record Animal
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public int AnimalTypeId { get; set; }
        public IQueryable<AnimalType> Types { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsMasculine { get; set; }
    }
}
