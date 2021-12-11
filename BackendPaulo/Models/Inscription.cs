using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class Inscription
    {
        public string Research { get; set; }
        public string Participant { get; set; }
        public string CreateDate { get; set; }

        public virtual Participant ParticipantNavigation { get; set; }
        public virtual Research ResearchNavigation { get; set; }
    }
}
