using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Dokumenty
    {
        public Dokumenty()
        {
            Zapisy = new HashSet<Zapisy>();
        }

        public short RokId { get; set; }
        public byte Zrodlo { get; set; }
        public int Id { get; set; }
        public string Skrot { get; set; }
        public int? Tabela { get; set; }
        public string Waluta { get; set; }
        public short OkresDk { get; set; }
        public int? Kontrahent { get; set; }
        public int? KontrahentStalyId { get; set; }
        public int? KontrahentJednId { get; set; }
        public string Nazwa { get; set; }
        public int Numer { get; set; }
        public short Wzorzec { get; set; }
        public int? IdLog { get; set; }
        public int Errors { get; set; }
        public string Tresc { get; set; }
        public DateTime Datawpr { get; set; }
        public DateTime? Datadok { get; set; }
        public DateTime? Dataokr { get; set; }
        public DateTime? DataOper { get; set; }
        public DateTime? Datawpl { get; set; }
        public int IdRozrach { get; set; }
        public double Kwota { get; set; }
        public double Wkwota { get; set; }
        public double KwotaZrow { get; set; }
        public byte Typkursu { get; set; }
        public string NazwaKor { get; set; }
        public DateTime? DataKor { get; set; }
        public string Sygnatura { get; set; }
        public string Nip { get; set; }
        public short Automat { get; set; }
        public short Flag { get; set; }
        public int NumerDk { get; set; }
        public double SaldoPoczRk { get; set; }
        public double SaldoZapRk { get; set; }
        public short PrzeksKr { get; set; }
        public double KwotaPozaRej { get; set; }
        public double Kurs { get; set; }
        public double KursEuro { get; set; }
        public int? NumerKsiegowania { get; set; }
        public int? KontrahentTt { get; set; }
        public Guid? UniqueZrodloNotKsiegi { get; set; }
        public Guid? UniqueZrodloWzorce { get; set; }
        public Guid? UniqueKontrahent { get; set; }
        public short? Spid { get; set; }
        public int Flagi { get; set; }
        public double? KwotaDzpb { get; set; }
        public string Znacznik { get; set; }
        public int TemplateId { get; set; }
        public Guid Uid { get; set; }
        public short? Okres { get; set; }
        public short EStatus { get; set; }
        public short Sdstatus { get; set; }
        public int? Danekh { get; set; }
        public short RodzajDk { get; set; }
        public short? MppFlags { get; set; }
        public string AtrJpkV7 { get; set; }
        public DateTime? Dataodprawy { get; set; }
        public short StatusKsef { get; set; }
        public Guid? GuidEarch { get; set; }
        public string NumberKsef { get; set; }

        public virtual Frok Rok { get; set; }
        public virtual Kursy TabelaNavigation { get; set; }
        public virtual Waluty WalutaNavigation { get; set; }
        public virtual ICollection<Zapisy> Zapisy { get; set; }
    }
}
