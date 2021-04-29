using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class AnimalPlaceProcess
    {
        public int ?AnimalPlaceId { get; set; }
        public AnimalPlace AnimalPlace { get; set; }

       
        public int ?ProcessId { get; set; }
        public Process Process { get; set; }

     
        public DateTime Date { get; set; }
    }
}
