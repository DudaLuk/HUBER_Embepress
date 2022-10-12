using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Frok
    {
        public Frok()
        {
            Dokumenty = new HashSet<Dokumenty>();
            Plankont = new HashSet<Plankont>();
            Zapisy = new HashSet<Zapisy>();
        }

        public short RokId { get; set; }
        public string Katalog { get; set; }
        public byte Zamkniety { get; set; }
        public byte Archiw { get; set; }
        public byte McZamkniety { get; set; }
        public byte BilansOtw { get; set; }
        public byte ObrotyRozp { get; set; }
        public byte Rozrachunki { get; set; }
        public byte KsAutomat { get; set; }
        public short Koszty { get; set; }
        public DateTime Poczatek { get; set; }
        public DateTime Koniec { get; set; }
        public short Dlugosc { get; set; }
        public byte Waluty { get; set; }
        public double Gus1 { get; set; }
        public double Gus2 { get; set; }
        public double W1 { get; set; }
        public double W2 { get; set; }
        public double W3 { get; set; }
        public double Zzl { get; set; }
        public double Zvat { get; set; }
        public double Zr1 { get; set; }
        public double Zr2 { get; set; }
        public double Zwal { get; set; }
        public short RegulaRk { get; set; }
        public short ValidBo { get; set; }
        public short NiePrzelicz { get; set; }
        public double KwotaPrzeks { get; set; }
        public short OkresOr { get; set; }
        public short ProgramOk { get; set; }
        public byte MiejsceRk { get; set; }
        public string DokumentRk { get; set; }
        public string DokumentKmp { get; set; }
        public byte PrzeksRw { get; set; }
        public byte OrnaKontach { get; set; }
        public short Wlasnosc { get; set; }
        public short TypDzial { get; set; }
        public byte NumeracjaDk { get; set; }
        public short StatusP { get; set; }

        public virtual ICollection<Dokumenty> Dokumenty { get; set; }
        public virtual ICollection<Plankont> Plankont { get; set; }
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}
