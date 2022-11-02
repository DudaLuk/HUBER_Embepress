using System;

namespace GenerateReport
{
    public class RaportRow
    {
        public int Okres { get; set; }
        public string Typdokumentu { get; set; }
        public int Numerewidencyjny{ get; set; }
        public string Numerdokumentu{ get; set; }
        public string Kontokalkulacyjne5{ get; set; }
        public string Nazwakontakalkulacyjnego{ get; set; }
        public double KwotaWaluta{ get; set; }
        public string Waluta{ get; set; }
        public double KwotaPLN{ get; set; }
        public string KontoKalkulacyjne4{ get; set; }
        public string Nazwakontarodzajowego{ get; set; }
        public string Opis{ get; set; }
        public string Nrkontrahenta{ get; set; }
        public string Nazwakontrahenta{ get; set; }
        public DateTime? Datadokumentu{ get; set; }
        public DateTime Datawprowadzenia { get; set; }
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