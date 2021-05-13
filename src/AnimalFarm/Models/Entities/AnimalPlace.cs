using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class AnimalPlace
    {
        [Key]
        public int Id { get; init; }

        public DateTime Lease { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public ICollection<AnimalPlaceProcess> AnimalPlaceProcesses { get; set; }
    }
}
