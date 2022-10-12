using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class Stcontractors
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Shortcut { get; set; }
        public string Name { get; set; }
        public byte NaturalPerson { get; set; }
        public string Nip { get; set; }
        public string Pesel { get; set; }
        public string Regon { get; set; }
        public string NipUe { get; set; }
        public string Note { get; set; }
        public Guid? ContactGuid { get; set; }
        public Guid? BankingInfoGuid { get; set; }
        public bool LimitFlag { get; set; }
        public double LimitAmount { get; set; }
        public string LimitCurrency { get; set; }
        public bool Vies { get; set; }
        public bool Negotiation { get; set; }
        public bool VatpayerActive { get; set; }
        public bool LinkedUnit { get; set; }
        public Guid MainElement { get; set; }
        public Guid? MainPerson { get; set; }
        public DateTime? StLastModified { get; set; }
        public byte[] StShadowdata { get; set; }
    }
}
