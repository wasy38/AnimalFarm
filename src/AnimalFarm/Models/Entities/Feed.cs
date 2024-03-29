﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class Feed
    {
        [Key]
        public int Id { get; init; }

        public ICollection<FeedProcess> FeedPocesses { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Привышено количесто символов")]
        [StringLength(100)]
        public string Name { get; set; }

        public int Count { get; set; }
    }
}
