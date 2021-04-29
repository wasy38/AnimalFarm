using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class FeedProcess
    {
        public int? FeedId { get; set; }
        public Feed Feed { get; set; }


        public int? ProcessId { get; set; }
        public Process Process { get; set; }


        public DateTime Date { get; set; }

    }
}
