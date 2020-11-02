using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommandsReminder.Models
{
    public class Platform
    {
        [Key]
        [JsonIgnore]
        public int PlatformId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        public List<CommandPlatform> CommandPlatforms { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Command> Commands { get; set; }
    }
}
