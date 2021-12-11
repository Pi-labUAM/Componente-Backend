using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPaulo.Models
{
    public partial class Talk
    {
        public string CreateDate { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
    }
}
