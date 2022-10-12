using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Zapisy
    {
        public short RokId { get; set; }
        public int Id { get; set; }
        public string Waluta { get; set; }
        public int? Tabela { get; set; }
        public int IdDlaRozliczen { get; set; }
        public int? Dokument { get; set; }
        public short Pozycja { get; set; }
        public short Rozbicie { get; set; }
        public byte Typopisu { get; set; }
        public byte TypRozb { get; set; }
        public double Kwota { get; set; }
        public double Wkwota { get; set; }
        public byte ZapisRownolegly { get; set; }
        public short Strona { get; set; }
        public byte Automat { get; set; }
        public byte KontoRap { get; set; }
        public DateTime? Dataokr { get; set; }
        public DateTime? DataZap { get; set; }
        public string Opis { get; set; }
        public int? Synt { get; set; }
        public int Poz1 { get; set; }
        public int Poz2 { get; set; }
        public int Poz3 { get; set; }
        public int Poz4 { get; set; }
        public int Poz5 { get; set; }
        public double Kurs { get; set; }
        public short Przeks { get; set; }
        public string NumerDok { get; set; }
        public short NrRozbKp { get; set; }
        public byte Typkursu { get; set; }
        public short PrzeksKr { get; set; }
        public double KursEuro { get; set; }
        public double PrzeksKwota { get; set; }
        public double PrzeksKurs { get; set; }
        public DateTime? PrzeksData { get; set; }
        public int? KontraktId { get; set; }
        public byte ZapisVat { get; set; }
        public Guid Uid { get; set; }
        public DateTime? DataKpkw { get; set; }

        public virtual Dokumenty Dokumenty { get; set; }
        public virtual Kontrakty Kontrakt { get; set; }
        public virtual Frok Rok { get; set; }
        public virtual Kursy TabelaNavigation { get; set; }
        public virtual Waluty WalutaNavigation { get; set; }
    }
}
