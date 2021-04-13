using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record Species
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(100,ErrorMessage ="Слишком много букв")]
        public string Name { get; set; }

        public IEnumerable<Animal> Animals { get; set; }
    }
}
