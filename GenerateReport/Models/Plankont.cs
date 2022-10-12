using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Plankont
    {
        public short RokId { get; set; }
        public int Id { get; set; }
        public byte Analit { get; set; }
        public byte Typ { get; set; }
        public byte Podtyp { get; set; }
        public byte Flagi { get; set; }
        public string Skrot { get; set; }
        public string Nazwa { get; set; }
        public int Syntet { get; set; }
        public int Typ1 { get; set; }
        public int Wart1 { get; set; }
        public int Typ2 { get; set; }
        public int Wart2 { get; set; }
        public int Typ3 { get; set; }
        public int Wart3 { get; set; }
        public int Typ4 { get; set; }
        public int Wart4 { get; set; }
        public int Typ5 { get; set; }
        public int Wart5 { get; set; }
        public int Generacja { get; set; }
        public byte KontrolaSaldaWb { get; set; }
        public byte KontoKk { get; set; }
        public byte KontrolaRozrach { get; set; }
        public short Rvat { get; set; }
        public short Listek { get; set; }
        public Guid Guid { get; set; }

        public virtual Frok Rok { get; set; }
    }
}
