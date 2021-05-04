using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; init; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Дебил куда так много буков?")]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(25, ErrorMessage = "Дебил куда так много буков?")]
        public string SecondName { get; init; }

        [Required]
        [MaxLength(25, ErrorMessage = "Дебил куда так много буков?")]
        public string Patronymic { get; init; }

        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Дебил куда так много буков?")]
        public string Phone { get; init; }

        [Required]
        [MaxLength(100, ErrorMessage = "Дебил куда так много буков?")]
        public string Email { get; init; }
        public bool IsWork { get; set; }

        public ICollection<Process> Processes { get; set; }
        public ICollection<EmployeeProcess> EmployeePocesses { get; set; }
    }
}
