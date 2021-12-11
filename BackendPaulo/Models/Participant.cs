using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class Participant
    {
        public Participant()
        {
            Inscriptions = new HashSet<Inscription>();
        }

        public string Document { get; set; }
        public string Picture { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
