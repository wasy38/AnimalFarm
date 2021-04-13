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

        public DateTime Birthday { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

    }
}
