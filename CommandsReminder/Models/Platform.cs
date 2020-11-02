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
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; }
    }
}
