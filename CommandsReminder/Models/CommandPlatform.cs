using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsReminder.Models
{
    public class CommandPlatform
    {
        public int CommandId { get; set; }
        public Command Command { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
