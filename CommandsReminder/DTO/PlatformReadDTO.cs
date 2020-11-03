using CommandsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.DTO
{
    public class PlatformReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}
