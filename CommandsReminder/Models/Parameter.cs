using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CommandsReminder.Models
{
    public class Parameter
    {
        [Key]
        [JsonIgnore]
        public int ParameterId { get; set; }

        public string String { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }
    }
}
