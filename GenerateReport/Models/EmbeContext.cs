using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GenerateReport.Models
{
    public partial class EmbeContext : DbContext
    {
        public EmbeContext()
        {
        }

        public EmbeContext(DbContextOptions<EmbeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dokumenty> Dokumenty { get; set; }
        public virtual DbSet<Frok> Frok { get; set; }
        public virtual DbSet<Kontrakty> Kontrakty { get; set; }
        public virtual DbSet<Kursy> Kursy { get; set; }
        public virtual DbSet<Plankont> Plankont { get; set; }
        public virtual DbSet<Stcontractors> Stcontractors { get; set; }
        public virtual DbSet<Waluty> Waluty { get; set; }
        public virtual DbSet<Zapisy> Zapisy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.;Database=Embe;Trusted_Connection=True;");
                //
                optionsBuilder.UseSqlServer("Server=.;Database=F_H_MEBLOHURT_Sylwester_Lalak_50C;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dokumenty>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RokId });

                entity.ToTable("dokumenty", "FK");

                entity.HasIndex(e => e.Danekh)
                    .HasName("idxDokumenty_danekh");

                entity.HasIndex(e => e.IdLog)
                    .HasName("idxDokumenty_idLog");

                entity.HasIndex(e => e.KontrahentStalyId)
                    .HasName("idxDokumenty_idKontrStaly");

                entity.HasIndex(e => e.Spid)
                    .HasName("idxDokumenty_SPID");

                entity.HasIndex(e => e.Uid)
                    .HasName("idxDokumenty_uid")
                    .IsUnique();

                entity.HasIndex(e => new { e.RokId, e.Automat })
                    .HasName("idxDokumenty_automat");

                entity.HasIndex(e => new { e.RokId, e.Datadok })
                    .HasName("idxDokumenty_datadok");

                entity.HasIndex(e => new { e.RokId, e.Dataokr })
                    .HasName("idxDokumenty_dataokr");

                entity.HasIndex(e => new { e.RokId, e.Datawpr })
                    .HasName("idxDokumenty_datawpr");

                entity.HasIndex(e => new { e.RokId, e.Kontrahent })
                    .HasName("idxDokumenty_kontr");

                entity.HasIndex(e => new { e.RokId, e.KontrahentJednId })
                    .HasName("idxDokumenty_idKontrJedn");

                entity.HasIndex(e => new { e.RokId, e.Kwota })
                    .HasName("idxDokumenty_kwota");

                entity.HasIndex(e => new { e.RokId, e.Nazwa })
                    .HasName("idxDokumenty_nazwa");

                entity.HasIndex(e => new { e.RokId, e.Sygnatura })
                    .HasName("idxDokumenty_sygnatura");

                entity.HasIndex(e => new { e.NumerKsiegowania, e.RokId, e.Zrodlo })
                    .HasName("idxDokumenty_numerKsiegowania");

                entity.HasIndex(e => new { e.RokId, e.Kontrahent, e.Datadok })
                    .HasName("idxDokumenty_kontrData");

                entity.HasIndex(e => new { e.RokId, e.RodzajDk, e.NumerDk })
                    .HasName("idxDokumenty_rodzajDK");

                entity.HasIndex(e => new { e.RokId, e.UniqueZrodloNotKsiegi, e.NumerKsiegowania })
                    .HasName("UQ_dokumenty_numerKsiegowania")
                    .IsUnique();

                entity.HasIndex(e => new { e.RokId, e.Id, e.Skrot, e.Numer })
                    .HasName("UQ_dokumenty_rokId_id_skrot_numer")
                    .IsUnique();

                entity.HasIndex(e => new { e.RokId, e.Id, e.Zrodlo, e.Skrot })
                    .HasName("idxDokumenty_zrodlo_skrot");

                entity.HasIndex(e => new { e.RokId, e.UniqueZrodloNotKsiegi, e.OkresDk, e.NumerDk })
                    .HasName("UQ_dokumenty_okreDK_numerDK")
                    .IsUnique();

                entity.HasIndex(e => new { e.NumerDk, e.RodzajDk, e.RokId, e.Zrodlo, e.OkresDk })
                    .HasName("idxDokumenty_NumerDK");

                entity.HasIndex(e => new { e.RokId, e.Skrot, e.Okres, e.Zrodlo, e.Numer })
                    .HasName("idxDokumenty_numer_skrot_rok_zrodlo");

                entity.HasIndex(e => new { e.RokId, e.UniqueZrodloWzorce, e.Skrot, e.Okres, e.Numer })
                    .HasName("UQ_dokumenty_skrot_numer")
                    .IsUnique();

                entity.HasIndex(e => new { e.Id, e.Numer, e.Dataokr, e.RokId, e.Skrot, e.Wzorzec })
                    .HasName("IDX_dokumenty_rokId_skrot_wzorzec");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RokId).HasColumnName("rokId");

                entity.Property(e => e.AtrJpkV7)
                    .IsRequired()
                    .HasColumnName("atrJpkV7")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Automat).HasColumnName("automat");

                entity.Property(e => e.Danekh).HasColumnName("danekh");

                entity.Property(e => e.DataKor)
                    .HasColumnName("dataKor")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataOper)
                    .HasColumnName("dataOper")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datadok)
                    .HasColumnName("datadok")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dataodprawy)
                    .HasColumnName("dataodprawy")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dataokr)
                    .HasColumnName("dataokr")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datawpl)
                    .HasColumnName("datawpl")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datawpr)
                    .HasColumnName("datawpr")
                    .HasColumnType("datetime");

                entity.Property(e => e.EStatus).HasColumnName("eStatus");

                entity.Property(e => e.Errors).HasColumnName("errors");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.Flagi).HasColumnName("flagi");

                entity.Property(e => e.GuidEarch).HasColumnName("guidEarch");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.IdRozrach).HasColumnName("idRozrach");

                entity.Property(e => e.Kontrahent).HasColumnName("kontrahent");

                entity.Property(e => e.KontrahentJednId).HasColumnName("kontrahentJednId");

                entity.Property(e => e.KontrahentStalyId).HasColumnName("kontrahentStalyId");

                entity.Property(e => e.KontrahentTt).HasColumnName("kontrahentTT");

                entity.Property(e => e.Kurs).HasColumnName("kurs");

                entity.Property(e => e.KursEuro).HasColumnName("kursEuro");

                entity.Property(e => e.Kwota).HasColumnName("kwota");

                entity.Property(e => e.KwotaDzpb).HasColumnName("kwotaDZPB");

                entity.Property(e => e.KwotaPozaRej).HasColumnName("kwotaPozaRej");

                entity.Property(e => e.KwotaZrow).HasColumnName("kwotaZRow");

                entity.Property(e => e.MppFlags)
                    .HasColumnName("mppFlags")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nazwa)
                    .HasColumnName("nazwa")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaKor)
                    .HasColumnName("nazwaKor")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nip)
                    .HasColumnName("nip")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumberKsef)
                    .HasColumnName("numberKsef")
                    .HasMaxLength(38)
                    .IsUnicode(false);

                entity.Property(e => e.Numer).HasColumnName("numer");

                entity.Property(e => e.NumerDk).HasColumnName("numerDK");

                entity.Property(e => e.NumerKsiegowania).HasColumnName("numerKsiegowania");

                entity.Property(e => e.Okres)
                    .HasColumnName("okres")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OkresDk).HasColumnName("okresDK");

                entity.Property(e => e.PrzeksKr).HasColumnName("przeksKR");

                entity.Property(e => e.RodzajDk).HasColumnName("rodzajDK");

                entity.Property(e => e.SaldoPoczRk).HasColumnName("saldoPoczRK");

                entity.Property(e => e.SaldoZapRk).HasColumnName("saldoZapRK");

                entity.Property(e => e.Sdstatus).HasColumnName("SDstatus");

                entity.Property(e => e.Skrot)
                    .IsRequired()
                    .HasColumnName("skrot")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Spid).HasColumnName("spid");

                entity.Property(e => e.StatusKsef).HasColumnName("statusKsef");

                entity.Property(e => e.Sygnatura)
                    .IsRequired()
                    .HasColumnName("sygnatura")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Tabela).HasColumnName("tabela");

                entity.Property(e => e.TemplateId).HasColumnName("templateId");

                entity.Property(e => e.Tresc)
                    .HasColumnName("tresc")
                    .HasMaxLength(59)
                    .IsUnicode(false);

                entity.Property(e => e.Typkursu).HasColumnName("typkursu");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UniqueKontrahent)
                    .HasColumnName("uniqueKontrahent")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UniqueZrodloNotKsiegi)
                    .HasColumnName("uniqueZrodloNotKsiegi")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UniqueZrodloWzorce)
                    .HasColumnName("uniqueZrodloWzorce")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Waluta)
                    .HasColumnName("waluta")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Wkwota).HasColumnName("wkwota");

                entity.Property(e => e.Wzorzec).HasColumnName("wzorzec");

                entity.Property(e => e.Znacznik)
                    .HasColumnName("znacznik")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Zrodlo).HasColumnName("zrodlo");

                entity.HasOne(d => d.Rok)
                    .WithMany(p => p.Dokumenty)
                    .HasForeignKey(d => d.RokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dokumenty_FROK");

                entity.HasOne(d => d.TabelaNavigation)
                    .WithMany(p => p.Dokumenty)
                    .HasForeignKey(d => d.Tabela)
                    .HasConstraintName("FK_dokumenty_kursy");

                entity.HasOne(d => d.WalutaNavigation)
                    .WithMany(p => p.Dokumenty)
                    .HasForeignKey(d => d.Waluta)
                    .HasConstraintName("FK_dokumenty_waluty");
            });

            modelBuilder.Entity<Frok>(entity =>
            {
                entity.HasKey(e => e.RokId);

                entity.ToTable("FROK", "FK");

                entity.HasIndex(e => e.Katalog)
                    .HasName("UQ_FROK_katalog")
                    .IsUnique();

                entity.Property(e => e.RokId)
                    .HasColumnName("rokId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Archiw).HasColumnName("archiw");

                entity.Property(e => e.BilansOtw).HasColumnName("bilansOtw");

                entity.Property(e => e.Dlugosc).HasColumnName("dlugosc");

                entity.Property(e => e.DokumentKmp)
                    .HasColumnName("dokumentKMP")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DokumentRk)
                    .IsRequired()
                    .HasColumnName("dokumentRK")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Gus1).HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Gus2).HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Katalog)
                    .IsRequired()
                    .HasColumnName("katalog")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Koniec)
                    .HasColumnName("koniec")
                    .HasColumnType("datetime");

                entity.Property(e => e.Koszty).HasColumnName("koszty");

                entity.Property(e => e.KsAutomat).HasColumnName("ksAutomat");

                entity.Property(e => e.KwotaPrzeks).HasColumnName("kwotaPrzeks");

                entity.Property(e => e.McZamkniety).HasColumnName("mcZamkniety");

                entity.Property(e => e.MiejsceRk).HasColumnName("miejsceRK");

                entity.Property(e => e.NiePrzelicz).HasColumnName("niePrzelicz");

                entity.Property(e => e.NumeracjaDk).HasColumnName("numeracjaDK");

                entity.Property(e => e.ObrotyRozp).HasColumnName("obrotyRozp");

                entity.Property(e => e.OkresOr).HasColumnName("okresOR");

                entity.Property(e => e.OrnaKontach).HasColumnName("ORnaKontach");

                entity.Property(e => e.Poczatek)
                    .HasColumnName("poczatek")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProgramOk).HasColumnName("programOK");

                entity.Property(e => e.PrzeksRw).HasColumnName("przeksRW");

                entity.Property(e => e.RegulaRk).HasColumnName("regulaRK");

                entity.Property(e => e.Rozrachunki).HasColumnName("rozrachunki");

                entity.Property(e => e.StatusP).HasColumnName("statusP");

                entity.Property(e => e.TypDzial).HasColumnName("typDzial");

                entity.Property(e => e.ValidBo).HasColumnName("validBO");

                entity.Property(e => e.W1).HasDefaultValueSql("((0.01))");

                entity.Property(e => e.W2).HasDefaultValueSql("((0.01))");

                entity.Property(e => e.W3).HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Waluty).HasColumnName("waluty");

                entity.Property(e => e.Wlasnosc).HasColumnName("wlasnosc");

                entity.Property(e => e.Zamkniety).HasColumnName("zamkniety");

                entity.Property(e => e.Zr1)
                    .HasColumnName("ZR1")
                    .HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Zr2)
                    .HasColumnName("ZR2")
                    .HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Zvat)
                    .HasColumnName("ZVat")
                    .HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Zwal)
                    .HasColumnName("ZWal")
                    .HasDefaultValueSql("((0.01))");

                entity.Property(e => e.Zzl)
                    .HasColumnName("ZZl")
                    .HasDefaultValueSql("((0.01))");
            });

            modelBuilder.Entity<Kontrakty>(entity =>
            {
                entity.ToTable("kontrakty", "FK");

                entity.HasIndex(e => e.DataOtwarcia)
                    .HasName("idxKontrakty_dataOtwarcia");

                entity.HasIndex(e => e.DataWprowadzenia)
                    .HasName("idxKontrakty_dataWprowadzenia");

                entity.HasIndex(e => e.Numer)
                    .HasName("UQ_kontrakty_numer")
                    .IsUnique();

                entity.HasIndex(e => e.Waluta)
                    .HasName("idxKontrakty_waluta");

                entity.HasIndex(e => e.Zamkniety)
                    .HasName("idxKontrakty_zamkniety");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataOtwarcia)
                    .HasColumnName("dataOtwarcia")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([char](10),getdate(),(112)))");

                entity.Property(e => e.DataWprowadzenia)
                    .HasColumnName("dataWprowadzenia")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([char](10),getdate(),(112)))");

                entity.Property(e => e.Generacja).HasColumnName("generacja");

                entity.Property(e => e.Numer)
                    .IsRequired()
                    .HasColumnName("numer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObrotyMa).HasColumnName("obrotyMa");

                entity.Property(e => e.ObrotyWalutoweMa).HasColumnName("obrotyWalutoweMa");

                entity.Property(e => e.ObrotyWalutoweWn).HasColumnName("obrotyWalutoweWn");

                entity.Property(e => e.ObrotyWn).HasColumnName("obrotyWn");

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Waluta)
                    .HasColumnName("waluta")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Zamkniety).HasColumnName("zamkniety");

                entity.HasOne(d => d.WalutaNavigation)
                    .WithMany(p => p.Kontrakty)
                    .HasForeignKey(d => d.Waluta)
                    .HasConstraintName("FK_kontrakty_waluty");
            });

            modelBuilder.Entity<Kursy>(entity =>
            {
                entity.ToTable("kursy", "FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sprz).HasColumnName("sprz");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnName("symbol")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Tabela)
                    .HasColumnName("tabela")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uzyte).HasColumnName("uzyte");

                entity.Property(e => e.Waluta)
                    .HasColumnName("waluta")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Zakup).HasColumnName("zakup");

                entity.HasOne(d => d.WalutaNavigation)
                    .WithMany(p => p.Kursy)
                    .HasForeignKey(d => d.Waluta);
            });

            modelBuilder.Entity<Plankont>(entity =>
            {
                entity.HasKey(e => new { e.RokId, e.Id });

                entity.ToTable("plankont", "FK");

                entity.HasIndex(e => e.Guid)
                    .HasName("UQ_plankont_guid")
                    .IsUnique();

                entity.HasIndex(e => e.RokId)
                    .HasName("idxPlankont_rokId");

                entity.HasIndex(e => new { e.RokId, e.Id, e.Syntet })
                    .HasName("UQ_plankont_syntet")
                    .IsUnique();

                entity.HasIndex(e => new { e.RokId, e.Syntet, e.Typ1, e.Wart1, e.Typ2, e.Wart2, e.Typ3, e.Wart3, e.Typ4, e.Wart4, e.Typ5, e.Wart5 })
                    .HasName("UQ_plankont_konto")
                    .IsUnique();

                entity.HasIndex(e => new { e.Skrot, e.Nazwa, e.RokId, e.Syntet, e.Typ1, e.Wart1, e.Typ2, e.Wart2, e.Typ3, e.Wart3, e.Typ4, e.Wart4, e.Typ5, e.Wart5 })
                    .HasName("idxPlankont_all");

                entity.Property(e => e.RokId).HasColumnName("rokId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Analit).HasColumnName("analit");

                entity.Property(e => e.Flagi).HasColumnName("flagi");

                entity.Property(e => e.Generacja).HasColumnName("generacja");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.KontoKk).HasColumnName("kontoKK");

                entity.Property(e => e.KontrolaRozrach).HasColumnName("kontrolaRozrach");

                entity.Property(e => e.KontrolaSaldaWb).HasColumnName("kontrolaSaldaWB");

                entity.Property(e => e.Listek)
                    .HasColumnName("listek")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nazwa)
                    .HasColumnName("nazwa")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Podtyp).HasColumnName("podtyp");

                entity.Property(e => e.Rvat).HasColumnName("rvat");

                entity.Property(e => e.Skrot)
                    .IsRequired()
                    .HasColumnName("skrot")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Syntet).HasColumnName("syntet");

                entity.Property(e => e.Typ).HasColumnName("typ");

                entity.Property(e => e.Typ1).HasColumnName("typ1");

                entity.Property(e => e.Typ2).HasColumnName("typ2");

                entity.Property(e => e.Typ3).HasColumnName("typ3");

                entity.Property(e => e.Typ4).HasColumnName("typ4");

                entity.Property(e => e.Typ5).HasColumnName("typ5");

                entity.Property(e => e.Wart1).HasColumnName("wart1");

                entity.Property(e => e.Wart2).HasColumnName("wart2");

                entity.Property(e => e.Wart3).HasColumnName("wart3");

                entity.Property(e => e.Wart4).HasColumnName("wart4");

                entity.Property(e => e.Wart5).HasColumnName("wart5");

                entity.HasOne(d => d.Rok)
                    .WithMany(p => p.Plankont)
                    .HasForeignKey(d => d.RokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_plankont_FROK");
            });

            modelBuilder.Entity<Stcontractors>(entity =>
            {
                entity.ToTable("STContractors", "SSCommon");

                entity.HasIndex(e => e.BankingInfoGuid)
                    .HasName("IDX_BankingInfoGuid");

                entity.HasIndex(e => e.ContactGuid)
                    .HasName("IDX_ContactGuid");

                entity.HasIndex(e => e.Guid)
                    .HasName("IDX_Guid")
                    .IsUnique();

                entity.HasIndex(e => e.MainElement)
                    .HasName("IDX_MainElement")
                    .IsUnique();

                entity.HasIndex(e => e.MainPerson)
                    .HasName("IDX_MainPerson");

                entity.HasIndex(e => e.Nip)
                    .HasName("IDX_NIP");

                entity.HasIndex(e => e.Shortcut)
                    .HasName("IDX_ShortCut");

                entity.HasIndex(e => new { e.Id, e.Shortcut, e.Name, e.Nip, e.ContactGuid, e.MainElement })
                    .HasName("IDX_Contractors_MainElement")
                    .IsUnique();

                entity.Property(e => e.LimitCurrency)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Nip)
                    .IsRequired()
                    .HasColumnName("NIP")
                    .HasMaxLength(20);

                entity.Property(e => e.NipUe)
                    .IsRequired()
                    .HasColumnName("NIP_UE")
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasColumnType("ntext");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasMaxLength(15);

                entity.Property(e => e.Regon)
                    .IsRequired()
                    .HasColumnName("REGON")
                    .HasMaxLength(20);

                entity.Property(e => e.Shortcut)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StLastModified)
                    .HasColumnName("st_last_modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StShadowdata)
                    .HasColumnName("st_shadowdata")
                    .HasColumnType("image");

                entity.Property(e => e.VatpayerActive).HasColumnName("VATPayerActive");

                entity.Property(e => e.Vies).HasColumnName("VIES");
            });

            modelBuilder.Entity<Waluty>(entity =>
            {
                entity.HasKey(e => e.Skrot);

                entity.ToTable("waluty", "FK");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ_waluty_id")
                    .IsUnique();

                entity.Property(e => e.Skrot)
                    .HasColumnName("skrot")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(39)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zapisy>(entity =>
            {
                entity.HasKey(e => new { e.RokId, e.Id })
                    .HasName("PK_zapisy_2");

                entity.ToTable("zapisy", "FK");

                entity.HasIndex(e => e.Tabela)
                    .HasName("idxZapisy_tabela");

                entity.HasIndex(e => e.Uid)
                    .HasName("idxZapisy_uid")
                    .IsUnique();

                entity.HasIndex(e => e.Waluta)
                    .HasName("idxZapisy_waluta");

                entity.HasIndex(e => new { e.KontraktId, e.Opis })
                    .HasName("idxZapisy_kontraktId_opis");

                entity.HasIndex(e => new { e.RokId, e.Dokument })
                    .HasName("idxZapisy_rokId_dokument");

                entity.HasIndex(e => new { e.Dokument, e.RokId, e.IdDlaRozliczen })
                    .HasName("UQ_zapisy_DokIdDlaRozliczen")
                    .IsUnique()
                    .HasFilter("([dokument] IS NOT NULL)");

                entity.HasIndex(e => new { e.RokId, e.Dokument, e.IdDlaRozliczen, e.Opis })
                    .HasName("idxZapisy_rokId_dokument_idDlaRozliczen_opis");

                entity.HasIndex(e => new { e.RokId, e.Dokument, e.Pozycja, e.Rozbicie })
                    .HasName("UQ_zapisy_DokPozycjaRozbicie")
                    .IsUnique()
                    .HasFilter("([dokument] IS NOT NULL)");

                entity.HasIndex(e => new { e.RokId, e.Synt, e.Poz1, e.Poz2, e.Poz3, e.Poz4, e.Poz5 })
                    .HasName("idxZapisy_kontr_aktywny");

                entity.HasIndex(e => new { e.RokId, e.Synt, e.Poz1, e.Poz2, e.Poz3, e.Poz4, e.Poz5, e.Dataokr })
                    .HasName("idxZapisy_virtualne_2");

                entity.HasIndex(e => new { e.RokId, e.Synt, e.Poz1, e.Poz2, e.Poz3, e.Poz4, e.Poz5, e.Przeks, e.Waluta })
                    .HasName("idxZapisy_przeks_2");

                entity.HasIndex(e => new { e.RokId, e.Dokument, e.Synt, e.Poz1, e.Poz2, e.Poz3, e.Poz4, e.Poz5, e.IdDlaRozliczen, e.Strona, e.Opis })
                    .HasName("idxZapisy_rokId_dokument_konto_opis");

                entity.Property(e => e.RokId).HasColumnName("rokId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Automat).HasColumnName("automat");

                entity.Property(e => e.DataKpkw)
                    .HasColumnName("dataKPKW")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataZap)
                    .HasColumnName("dataZap")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dataokr)
                    .HasColumnName("dataokr")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dokument).HasColumnName("dokument");

                entity.Property(e => e.IdDlaRozliczen).HasColumnName("idDlaRozliczen");

                entity.Property(e => e.KontoRap).HasColumnName("kontoRap");

                entity.Property(e => e.KontraktId).HasColumnName("kontraktId");

                entity.Property(e => e.Kurs).HasColumnName("kurs");

                entity.Property(e => e.KursEuro).HasColumnName("kursEuro");

                entity.Property(e => e.Kwota).HasColumnName("kwota");

                entity.Property(e => e.NrRozbKp).HasColumnName("nrRozbKP");

                entity.Property(e => e.NumerDok)
                    .HasColumnName("numerDok")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(59)
                    .IsUnicode(false);

                entity.Property(e => e.Poz1).HasColumnName("poz1");

                entity.Property(e => e.Poz2).HasColumnName("poz2");

                entity.Property(e => e.Poz3).HasColumnName("poz3");

                entity.Property(e => e.Poz4).HasColumnName("poz4");

                entity.Property(e => e.Poz5).HasColumnName("poz5");

                entity.Property(e => e.Pozycja).HasColumnName("pozycja");

                entity.Property(e => e.Przeks).HasColumnName("przeks");

                entity.Property(e => e.PrzeksData)
                    .HasColumnName("przeksData")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrzeksKr).HasColumnName("przeksKR");

                entity.Property(e => e.PrzeksKurs).HasColumnName("przeksKurs");

                entity.Property(e => e.PrzeksKwota).HasColumnName("przeksKwota");

                entity.Property(e => e.Rozbicie).HasColumnName("rozbicie");

                entity.Property(e => e.Strona).HasColumnName("strona");

                entity.Property(e => e.Synt).HasColumnName("synt");

                entity.Property(e => e.Tabela).HasColumnName("tabela");

                entity.Property(e => e.TypRozb).HasColumnName("typRozb");

                entity.Property(e => e.Typkursu).HasColumnName("typkursu");

                entity.Property(e => e.Typopisu).HasColumnName("typopisu");

                entity.Property(e => e.Uid)
                    .HasColumnName("uid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Waluta)
                    .HasColumnName("waluta")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Wkwota).HasColumnName("wkwota");

                entity.Property(e => e.ZapisRownolegly).HasColumnName("zapisRownolegly");

                entity.Property(e => e.ZapisVat).HasColumnName("zapisVat");

                entity.HasOne(d => d.Kontrakt)
                    .WithMany(p => p.Zapisy)
                    .HasForeignKey(d => d.KontraktId)
                    .HasConstraintName("FK_zapisy_kontraktId");

                entity.HasOne(d => d.Rok)
                    .WithMany(p => p.Zapisy)
                    .HasForeignKey(d => d.RokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_zapisy_FROK");

                entity.HasOne(d => d.TabelaNavigation)
                    .WithMany(p => p.Zapisy)
                    .HasForeignKey(d => d.Tabela)
                    .HasConstraintName("FK_zapisy_kursy");

                entity.HasOne(d => d.WalutaNavigation)
                    .WithMany(p => p.Zapisy)
                    .HasForeignKey(d => d.Waluta)
                    .HasConstraintName("FK_zapisy_waluty");

                entity.HasOne(d => d.Dokumenty)
                    .WithMany(p => p.Zapisy)
                    .HasForeignKey(d => new { d.Dokument, d.RokId })
                    .HasConstraintName("FK_zapisy_dokumenty_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
