using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.DTO
{
    public class PlatformCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [IgnoreMap]
        [Required]
        public List<int> CommandsId { get; set; }
    }
}
