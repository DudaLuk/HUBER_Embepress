using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Kontrakty
    {
        public Kontrakty()
        {
            Zapisy = new HashSet<Zapisy>();
        }

        public int Id { get; set; }
        public string Numer { get; set; }
        public byte Zamkniety { get; set; }
        public string Opis { get; set; }
        public DateTime DataWprowadzenia { get; set; }
        public DateTime DataOtwarcia { get; set; }
        public double ObrotyWn { get; set; }
        public double ObrotyMa { get; set; }
        public string Waluta { get; set; }
        public double ObrotyWalutoweWn { get; set; }
        public double ObrotyWalutoweMa { get; set; }
        public int Generacja { get; set; }

        public virtual Waluty WalutaNavigation { get; set; }
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}
