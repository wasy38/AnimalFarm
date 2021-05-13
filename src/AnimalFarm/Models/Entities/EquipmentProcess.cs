using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class EquipmentProcess
    {

        [Key]
        public int Id { get; init; }
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }


        public int? ProcessId { get; set; }
        public Process Process { get; set; }


        public DateTime Date { get; set; }

    }
}
