using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Waluty
    {
        public Waluty()
        {
            Dokumenty = new HashSet<Dokumenty>();
            Kontrakty = new HashSet<Kontrakty>();
            Kursy = new HashSet<Kursy>();
            Zapisy = new HashSet<Zapisy>();
        }

        public string Skrot { get; set; }
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Dokumenty> Dokumenty { get; set; }
        public virtual ICollection<Kontrakty> Kontrakty { get; set; }
        public virtual ICollection<Kursy> Kursy { get; set; }
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}
