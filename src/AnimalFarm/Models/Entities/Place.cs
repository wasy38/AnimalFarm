using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record Place
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(100, ErrorMessage ="Привышено количесто символов")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<AnimalPlace> AnimalPlaces { get; set; }
    }
}
