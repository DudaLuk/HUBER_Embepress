using ArrayToExcel;
using GenerateReport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GenerateReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (EmbeContext cx = new EmbeContext())
            {
                List<Frok> froks = cx.Frok.ToList();
                comboBox1.DataSource = froks;
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            }
            GetData();

        }

        private void GetData()
        {
            EmbeContext cx = new EmbeContext();
            List<RaportRow> raportRows = new List<RaportRow>();
            short rokId = (comboBox1.SelectedItem as Frok).RokId;
            foreach (var dokument in cx.Dokumenty.Include(d => d.Zapisy).Where(d => d.RokId == rokId && d.Numer != 0).ToList())
            {
                var zapisy4 = dokument.Zapisy.Where(zapis => zapis.Synt >= 400 && zapis.Synt <= 499 && zapis.Strona == 0);
                IEnumerable<IGrouping<string, Zapisy>> group4 = zapisy4.GroupBy(z => $"{z.Synt}-{z.Poz1}");

                var zapisy5 = dokument.Zapisy.Where(zapis => zapis.Synt >= 500 && zapis.Synt <= 599 && zapis.Strona == 0);
                IEnumerable<IGrouping<string, Zapisy>> group5 = zapisy5.GroupBy(z => $"{z.Synt}-{z.Poz1}");

                var suma4 = zapisy4.Sum(x => x.Kwota);
                var wsuma4 = zapisy4.Sum(x => x.Wkwota);
                var kontrahent = cx.Stcontractors.FirstOrDefault(kh => kh.Id == dokument.KontrahentStalyId);

                foreach (var g4 in group4)
                {
                    var z4 = g4.First();
                    Plankont konto4 = cx.Plankont.FirstOrDefault(konto =>
                    konto.Syntet == z4.Synt
                    && konto.Wart1 == z4.Poz1
                    && konto.Wart2 == z4.Poz2
                    && konto.Wart3 == z4.Poz3
                    && konto.Wart4 == z4.Poz4
                    && konto.Wart5 == z4.Poz5
                    && konto.RokId == z4.RokId);

                    raportRows.AddRange(group5.Select(groupz5 =>
                    {
                        var z5 = groupz5.First();
                        var suma = groupz5.Sum(g => g.Kwota);
                        var wsuma = groupz5.Sum(g => g.Wkwota);
                        Plankont konto5 = cx.Plankont.FirstOrDefault(konto =>
                       konto.Syntet == z5.Synt
                       && konto.Wart1 == z5.Poz1
                       && konto.RokId == z5.RokId);

                        RaportRow raportRow = new RaportRow();
                        raportRow.Okres = dokument.Dataokr.HasValue ? dokument.Dataokr.Value.Month : 0;
                        raportRow.Typdokumentu = dokument.Skrot;
                        raportRow.Numerewidencyjny = dokument.Numer;
                        raportRow.Numerdokumentu = dokument.Nazwa;
                        raportRow.Kontokalkulacyjne5 = "" + z5.Synt;
                        raportRow.Kontokalkulacyjne5 += z5.Poz1 == 0 ? "" : "-" + z5.Poz1 + "";
                        raportRow.Kontokalkulacyjne5 += z5.Poz2 == 0 ? "" : "-" + z5.Poz2 + "";
                        raportRow.Kontokalkulacyjne5 += z5.Poz3 == 0 ? "" : "-" + z5.Poz3 + "";
                        raportRow.Kontokalkulacyjne5 += z5.Poz4 == 0 ? "" : "-" + z5.Poz4 + "";
                        raportRow.Kontokalkulacyjne5 += z5.Poz5 == 0 ? "" : "-" + z5.Poz5 + "";
                        raportRow.Nazwakontakalkulacyjnego = konto5.Nazwa;
                        raportRow.KwotaPLN = suma * (g4.Sum(x => x.Kwota) / suma4);
                        if (wsuma4 != 0)
                        {
                            raportRow.KwotaWaluta = wsuma * (g4.Sum(x => x.Wkwota) / wsuma4);
                        }

                        raportRow.Waluta = z4.Waluta;



                        raportRow.KontoKalkulacyjne4 = "" + z4.Synt;
                        raportRow.KontoKalkulacyjne4 += z4.Poz1 == 0 ? "" : "-" + z4.Poz1 + "";
                        raportRow.KontoKalkulacyjne4 += z4.Poz2 == 0 ? "" : "-" + z4.Poz2 + "";
                        raportRow.KontoKalkulacyjne4 += z4.Poz3 == 0 ? "" : "-" + z4.Poz3 + "";
                        raportRow.KontoKalkulacyjne4 += z4.Poz4 == 0 ? "" : "-" + z4.Poz4 + "";
                        raportRow.KontoKalkulacyjne4 += z4.Poz5 == 0 ? "" : "-" + z4.Poz5 + "";
                        raportRow.Nazwakontarodzajowego = konto4.Nazwa;
                        raportRow.Opis = z4.Opis;
                        raportRow.Nrkontrahenta = "" + kontrahent?.Id ?? "";
                        raportRow.Nazwakontrahenta = kontrahent?.Name ?? "";


                        raportRow.Datadokumentu = dokument.Datadok;
                        raportRow.Datawprowadzenia = dokument.Datawpr;
                        return raportRow;
                    }
                )
                );
                }


            }


            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = raportRows;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void excel_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files | *.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, (dataGridView1.DataSource as List<RaportRow>).ToExcel());
            }

        }
    }






}
