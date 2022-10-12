using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Kursy
    {
        public Kursy()
        {
            Dokumenty = new HashSet<Dokumenty>();
            Zapisy = new HashSet<Zapisy>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Symbol { get; set; }
        public string Waluta { get; set; }
        public string Tabela { get; set; }
        public double Zakup { get; set; }
        public double Sprz { get; set; }
        public short Uzyte { get; set; }

        public virtual Waluty WalutaNavigation { get; set; }
        public virtual ICollection<Dokumenty> Dokumenty { get; set; }
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}
