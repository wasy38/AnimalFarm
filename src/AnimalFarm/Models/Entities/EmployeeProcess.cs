using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record EmployeeProcess
    {
        [Key]
        public int Id { get; init; }

        public int EmployeeId { get; set; }
        public IQueryable<Employee> Employees { get; set; }
        public int ProcessId { get; set; }
        public IQueryable<Process> Processes { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
