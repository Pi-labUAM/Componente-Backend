using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class Research
    {
        public Research()
        {
            Inscriptions = new HashSet<Inscription>();
        }

        public string CreateDate { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Objectives { get; set; }
        public string Results { get; set; }
        public string Bibliography { get; set; }
        public string State { get; set; }

        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
