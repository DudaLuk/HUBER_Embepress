using GenerateReport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ArrayToExcel;
using System.IO;
using EncryptStringSample;

namespace GenerateReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(StringCipher.Decrypt("7XfACTVUsdgKhm32AbitnF7KHTGvP+uP+csaCuNLS/SpKp4DwJ1/yTU9GIrQbjbVMcOTxh1tnZEeGYUpxWGIuZ4PqL+5pYGQsQyYT8/tC1D8vek7o8VdzXTtkNRBbCkKgVNC0SvrYb8Xumn2hHPC1SxbG9/IKrGDqqutYxKN3h/CqtcDMRA4q7UmoLtj6UXHwD58AOLgcNNJ3WAi2ZUnaw==", "zaq1@WSX"));

            List<RaportRow> raportRows = new List<RaportRow>();

            EmbeContext context = new EmbeContext();
            var dokumenty = context.Dokumenty.Include(dokument => dokument.Zapisy);

            foreach (Dokumenty dokument in dokumenty.Where(d => d.RokId == 1).ToList())
            {
                ProcesDokument(raportRows, context, dokument);
            }

            File.WriteAllBytes($@"test.xlsx".ToLower(), raportRows.ToExcel());
            Console.ReadKey();
        }

        private static void ProcesDokument(List<RaportRow> raportRows, EmbeContext context, Dokumenty dokument)
        {
            Console.WriteLine(dokument.Nazwa);
            IEnumerable<Zapisy> zapisy5 = dokument.Zapisy.Where(zapis => zapis.Synt >= 500 && zapis.Synt <= 599 && zapis.Strona == 0);
            IEnumerable<Zapisy> zapisy4 = dokument.Zapisy.Where(zapis => zapis.Synt >= 400 && zapis.Synt <= 499 && zapis.Strona == 0);
            var kontrahent = context.Stcontractors.FirstOrDefault(kh => kh.Id == dokument.KontrahentStalyId);
            if (zapisy5.Count() == 1)
            {
                JednaPiątka(raportRows, context, dokument, zapisy5, zapisy4, kontrahent);
            }

            if (zapisy5.Count() > 1)
            {
                WielePiątek(raportRows, context, dokument, zapisy5, zapisy4, kontrahent);
            }
        }

        private static void WielePiątek(List<RaportRow> raportRows, EmbeContext context, Dokumenty dokument, IEnumerable<Zapisy> zapisy5, IEnumerable<Zapisy> zapisy4, Stcontractors kontrahent)
        {
            var zapisy5kwotasum = zapisy5.Sum(z => z.Kwota);

            foreach (var zapis5 in zapisy5)
            {

                double zapisy4KwotaSum = zapisy4.Sum(z => z.Kwota) * zapis5.Kwota / zapisy5kwotasum;
                Plankont konto5 = context.Plankont.FirstOrDefault(konto =>
                        konto.Syntet == zapis5.Synt
                        && konto.Wart1 == zapis5.Poz1
                        && konto.Wart2 == zapis5.Poz2
                        && konto.Wart3 == zapis5.Poz3
                        && konto.Wart4 == zapis5.Poz4
                        && konto.Wart5 == zapis5.Poz5
                        && konto.RokId == zapis5.RokId);

                foreach (var zapis4 in zapisy4)
                {
                    RaportRow rr = new RaportRow();
                    rr.Okres = dokument.Okres.Value;
                    rr.Typdokumentu = dokument.Skrot;
                    rr.Numerewidencyjny = dokument.Numer;
                    rr.Numerdokumentu = dokument.Nazwa;
                    rr.Kontokalkulacyjne5 = $"{zapis5.Synt}-{zapis5.Poz1}-{zapis5.Poz2}-{zapis5.Poz3}-{zapis5.Poz4}-{zapis5.Poz5}";

                    rr.Nazwakontakalkulacyjnego = konto5?.Nazwa ?? "";
                    rr.KwotaPLN = zapis4.Kwota / zapisy4KwotaSum * zapis5.Kwota;
                    rr.KwotaWaluta = zapis4.Kwota / zapisy4KwotaSum * zapis5.Wkwota;
                    rr.Waluta = zapis4.Waluta;
                    rr.KontoKalkulacyjne4 = $"{zapis4.Synt}-{zapis4.Poz1}-{zapis4.Poz2}-{zapis4.Poz3}-{zapis4.Poz4}-{zapis4.Poz5}";
                    Plankont konto4 = context.Plankont.FirstOrDefault(konto =>
                        konto.Syntet == zapis4.Synt
                        && konto.Wart1 == zapis4.Poz1
                        && konto.Wart2 == zapis4.Poz2
                        && konto.Wart3 == zapis4.Poz3
                        && konto.Wart4 == zapis4.Poz4
                        && konto.Wart5 == zapis4.Poz5
                        && konto.RokId == zapis4.RokId);

                    rr.Nazwakontarodzajowego = konto4.Nazwa;
                    rr.Opis = zapis4.Opis;
                    rr.Nrkontrahenta = "" + kontrahent?.Id ?? "";
                    rr.Nazwakontrahenta = kontrahent?.Name ?? "";
                    rr.Datadokumentu = dokument.Datadok.ToString();
                    rr.Datawprowadzenia = dokument.Datawpr.ToString();
                    raportRows.Add(rr);



                }
            }
        }

        private static void JednaPiątka(List<RaportRow> raportRows, EmbeContext context, Dokumenty dokument, IEnumerable<Zapisy> zapisy5, IEnumerable<Zapisy> zapisy4, Stcontractors kontrahent)
        {
            var zapis5 = zapisy5.First();
            double zapisy4KwotaSum = zapisy4.Sum(z => z.Kwota);
            Plankont konto5 = context.Plankont.FirstOrDefault(konto =>
                    konto.Syntet == zapis5.Synt
                    && konto.Wart1 == zapis5.Poz1
                    && konto.Wart2 == zapis5.Poz2
                    && konto.Wart3 == zapis5.Poz3
                    && konto.Wart4 == zapis5.Poz4
                    && konto.Wart5 == zapis5.Poz5
                    && konto.RokId == zapis5.RokId);

            foreach (var zapis4 in zapisy4)
            {
                RaportRow rr = new RaportRow();
                rr.Okres = dokument.Okres.Value;
                rr.Typdokumentu = dokument.Skrot;
                rr.Numerewidencyjny = dokument.Numer;
                rr.Numerdokumentu = dokument.Nazwa;
                rr.Kontokalkulacyjne5 = $"{zapis5.Synt}-{zapis5.Poz1}-{zapis5.Poz2}-{zapis5.Poz3}-{zapis5.Poz4}-{zapis5.Poz5}";

                rr.Nazwakontakalkulacyjnego = konto5?.Nazwa ?? "";
                rr.KwotaPLN = zapis4.Kwota / zapisy4KwotaSum * zapis5.Kwota;
                rr.KwotaWaluta = zapis4.Kwota / zapisy4KwotaSum * zapis5.Wkwota;
                rr.Waluta = zapis4.Waluta;
                rr.KontoKalkulacyjne4 = $"{zapis4.Synt}-{zapis4.Poz1}-{zapis4.Poz2}-{zapis4.Poz3}-{zapis4.Poz4}-{zapis4.Poz5}";
                Plankont konto4 = context.Plankont.FirstOrDefault(konto =>
                    konto.Syntet == zapis4.Synt
                    && konto.Wart1 == zapis4.Poz1
                    && konto.Wart2 == zapis4.Poz2
                    && konto.Wart3 == zapis4.Poz3
                    && konto.Wart4 == zapis4.Poz4
                    && konto.Wart5 == zapis4.Poz5
                    && konto.RokId == zapis4.RokId);

                rr.Nazwakontarodzajowego = konto4.Nazwa;
                rr.Opis = zapis4.Opis;
                rr.Nrkontrahenta = "" + kontrahent?.Id ?? "";
                rr.Nazwakontrahenta = kontrahent?.Name ?? "";
                //Nr kontrahenta	Nazwa kontrahenta	Data dokumentu	Data wprowadzenia
                rr.Datadokumentu = dokument.Datadok.ToString();
                rr.Datawprowadzenia = dokument.Datawpr.ToString();
                raportRows.Add(rr);



            }
        }
    }




    public class RaportRow
    {
        public short Okres;
        public string Typdokumentu;
        public int Numerewidencyjny;
        public string Numerdokumentu;
        public string Kontokalkulacyjne5;
        public string Nazwakontakalkulacyjnego;
        public double KwotaWaluta;
        public string Waluta;
        public double KwotaPLN;
        public string KontoKalkulacyjne4;
        public string Nazwakontarodzajowego;
        public string Opis;
        public string Nrkontrahenta;
        public string Nazwakontrahenta;
        public string Datadokumentu;
        public string Datawprowadzenia;
    }

}
//Data Source=DESKTOP-JSCVUSC;Database=SchoolDB;Integrated Security=True;Connect imeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
//Scaffold-DbContext "Data Source=DESKTOP-JSCVUSC;Database=embe;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -tables [FK].[Zapisy] -verbose
//Scaffold-DbContext "Server=.;Database=Embe;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -tables fk.zapisy,FK.dokumenty,FK.FROK,FK.kontrakty,FK.kursy,FK.waluty

/*
 Each package is licensed to you by its owner. NuGet is not responsible for, nor does it grant any licenses to, third-party packages. Some packages may include dependencies which are governed by additional licenses. Follow the package source (feed) URL to determine any dependencies.

Package Manager Console Host Version 6.3.0.131

Type 'get-help NuGet' to see all available NuGet commands.

PM> Scaffold-DbContext "Server=.;Database=Embe;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -tables fk.zapisy
Build started...
Build succeeded.
For foreign key FK_zapisy_dokumenty_2 on table FK.zapisy, unable to model the end of the foreign key on principal table FK.dokumenty. This is usually because the principal table was not included in the selection set.
For foreign key FK_zapisy_FROK on table FK.zapisy, unable to model the end of the foreign key on principal table FK.FROK. This is usually because the principal table was not included in the selection set.
For foreign key FK_zapisy_kontraktId on table FK.zapisy, unable to model the end of the foreign key on principal table FK.kontrakty. This is usually because the principal table was not included in the selection set.
For foreign key FK_zapisy_kursy on table FK.zapisy, unable to model the end of the foreign key on principal table FK.kursy. This is usually because the principal table was not included in the selection set.
For foreign key FK_zapisy_waluty on table FK.zapisy, unable to model the end of the foreign key on principal table FK.waluty. This is usually because the principal table was not included in the selection set.
PM> 



https://github.com/mustaddon/ArrayToExcel/blob/master/Examples/Example.ConsoleApp/Program.cs
 */