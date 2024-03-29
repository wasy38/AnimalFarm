﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm.Models.Entities
{
    public class Process
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(100, ErrorMessage ="Слишком много букв")]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<AnimalPlaceProcess> AnimalPlaceProcesses { get; set; }

        public ICollection<EmployeeProcess> EmployeePocesses { get; set; }

        public ICollection<FeedProcess> FeedPocesses { get; set; }

        public ICollection<EquipmentProcess> EquipmentPocesses { get; set; }
    }
}

