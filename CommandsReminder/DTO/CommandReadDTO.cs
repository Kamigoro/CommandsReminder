using CommandsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.DTO
{
    public class CommandReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Example { get; set; }

        public ICollection<Platform> Platforms { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
