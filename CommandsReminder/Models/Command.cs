using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CommandsReminder.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Example { get; set; }

        [JsonIgnore]
        public ICollection<Platform> Platforms { get; set; }

        [JsonIgnore]
        public List<Parameter> Parameters { get; set; }
    }
}
