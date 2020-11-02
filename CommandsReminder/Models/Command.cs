using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommandsReminder.Models
{
    public class Command
    {
        [Key]
        [JsonIgnore]
        public int CommandId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Example { get; set; }

        [JsonIgnore]
        public List<CommandPlatform> CommandPlatforms { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Platform> Platforms { get; set; } = new List<Platform>();

        public List<Parameter> Parameters { get; set; }
    }
}
