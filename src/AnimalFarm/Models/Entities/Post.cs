using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Слишком много букв")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
