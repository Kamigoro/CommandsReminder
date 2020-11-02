using CommandsReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.DTO
{
    public class PlatformDTO
    {
        public string Name { get; set; }

        public List<Command> Commands { get; set; }
    }
}
