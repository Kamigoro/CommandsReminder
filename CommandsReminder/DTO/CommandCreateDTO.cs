using AutoMapper;
using CommandsReminder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.DTO
{
    public class CommandCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Example { get; set; }

        public List<Parameter> Parameters { get; set; }

        [IgnoreMap]
        [Required]
        public List<int> PlatformsId { get; set; }
    }
}
