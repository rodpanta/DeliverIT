using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace RestAPI.Models
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            ContasApagars = new HashSet<ContasApagar>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ContasApagar> ContasApagars { get; set; }
    }
}
