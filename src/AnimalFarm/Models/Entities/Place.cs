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
        [MaxLength(100, ErrorMessage = "Дебил куда так много буков?")]
        public string Name { get; init; }
    }
}
