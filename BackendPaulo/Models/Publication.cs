using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class Publication
    {
        public string CreateDate { get; set; }
        public string PublicationDate { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
