using System;

public class FKzapisy
{
    public short rokId { get; set; }
    public int id { get; set; }
    public string waluta { get; set; }
    public int? tabela { get; set; }
    public int idDlaRozliczen { get; set; }
    public int? dokument { get; set; }
    public short pozycja { get; set; }
    public short rozbicie { get; set; }
    public byte typopisu { get; set; }
    public byte typRozb { get; set; }
    public double kwota { get; set; }
    public double wkwota { get; set; }
    public byte zapisRownolegly { get; set; }
    public short strona { get; set; }
    public byte automat { get; set; }
    public byte kontoRap { get; set; }
    public DateTime? dataokr { get; set; }
    public DateTime? dataZap { get; set; }
    public string opis { get; set; }
    public int? synt { get; set; }
    public int poz1 { get; set; }
    public int poz2 { get; set; }
    public int poz3 { get; set; }
    public int poz4 { get; set; }
    public int poz5 { get; set; }
    public double kurs { get; set; }
    public short przeks { get; set; }
    public string numerDok { get; set; }
    public short nrRozbKP { get; set; }
    public byte typkursu { get; set; }
    public short przeksKR { get; set; }
    public double kursEuro { get; set; }
    public double przeksKwota { get; set; }
    public double przeksKurs { get; set; }
    public DateTime? przeksData { get; set; }
    public int? kontraktId { get; set; }
    public byte zapisVat { get; set; }
    public Guid uid { get; set; }
    public DateTime? dataKPKW { get; set; }
}
