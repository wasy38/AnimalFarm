using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class EquipmentProcess
    {
        public int? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }


        public int? ProcessId { get; set; }
        public Process Process { get; set; }


        public DateTime Date { get; set; }

    }
}
