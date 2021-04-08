using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public record FeedProcess
    {
        [Key]
        public int Id { get; init; }

        public int FeedId { get; set; }
        public IQueryable<Feed> Feeds { get; set; }
        public int ProcessId { get; set; }
        public IQueryable<Process> Processes { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
