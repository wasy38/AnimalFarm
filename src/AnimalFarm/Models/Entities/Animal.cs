using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AnimalFarm.Models.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; init; }

        public DateTime? Birthday { get; set; }

        public bool? IsMasculine { get; set; }

        public int? SpeciesId { get; set; }
        public Species Species { get; set; }

        public ICollection<AnimalPlace> AnimalPlaces { get; set; }

    }
}
