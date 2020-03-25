using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Dapper.Contrib.Extensions;
using EncryptStringSample;
using Microsoft.Data.ConnectionUI;

namespace ZapisyExcel
{
    public partial class Form1 : Form
    {
        string zapisyexcelConf = "zapisyExcel.conf";

        public SqlConnection sqlConnection { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionGet();
            //dataGridView1.DataSource= sqlConnection.GetAll<FKzapisy>();
           
        }

        private void ConnectionGet()
        {
            if (!File.Exists(zapisyexcelConf))
            {
                using (var dataConnectionDialog = new DataConnectionDialog())
                {
                    dataConnectionDialog.DataSources.Add(DataSource.SqlDataSource);
                    dataConnectionDialog.DataSources.Add(DataSource.SqlFileDataSource);
                    dataConnectionDialog.SelectedDataSource = DataSource.SqlDataSource;
                    dataConnectionDialog.SelectedDataProvider = DataProvider.SqlDataProvider;
                    if (DataConnectionDialog.Show(dataConnectionDialog) == DialogResult.OK)
                    {
                        var encrypt = StringCipher.Encrypt(dataConnectionDialog.ConnectionString, "zaq1@WSX");
                        File.WriteAllText(zapisyexcelConf, encrypt);
                        sqlConnection = new SqlConnection(dataConnectionDialog.ConnectionString);
                    }
                }
            }
            else
            {
                var decrypt = StringCipher.Decrypt(File.ReadAllText(zapisyexcelConf), "zaq1@WSX");
                sqlConnection = new SqlConnection(decrypt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rows = new List<Row>();
            var enumerable = sqlConnection.Query<Row>(
                $"select " +
                $"d.dataokr ," +
                $"z.synt," +
                $"z.poz1," +
                $"z.poz2," +
                $"z.poz3," +
                $"z.poz4," +
                $"	z.poz5," +
                $"	d.skrot," +
                $"	d.nazwa," +
                $"	d.numer," +
                $"	d.datawpr," +
                $"	d.datadok," +
                $"	d.tresc," +
                $"	z.strona," +
                $"	z.kwota," +
                $"	k.pozycja," +
                $"	k.nazwa knazwa," +
                $"	d.sygnatura," +
                $"  d.numerKsiegowania  " +
                $"	from fk.dokumenty d " +
                $"left join fk.zapisy z on z.dokument=d.id " +
                $"left join fk.fk_kontrahenci k on k.pozycja=d.kontrahentStalyId " +
                $"where datadok>='{monthCalendar1.SelectionStart}' and datadok<='{monthCalendar1.SelectionEnd}'");

           

            dataGridView1.DataSource = enumerable;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(";", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(";", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            //todo: poprawic zapisywanie pliku
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName,sb.ToString(),Encoding.Default);
            }
        }
    }




    public class Row
    {

        public string Okres
        {
            get
            {
                if (dataokr.HasValue)
                {
                    return dataokr.Value.Month.ToString();
                }

                return "";
            }
        }

        public string Konto
        {
            get
            {
                var s = string.Empty;
                if (synt.HasValue)
                {
                    s += synt.Value;
                }

                if (poz1!=0)
                {
                    s +="-"+ poz1;
                }
                if (poz2 != 0)
                {
                    s += "-" + poz2;
                }
                if (poz3 != 0)
                {
                    s += "-" + poz3;
                }
                if (poz4 != 0)
                {
                    s += "-" + poz4;
                }
                if (poz5 != 0)
                {
                    s += "-" + poz5;
                }

                return s;
            }
        }

        public string Typ_dokumentu => skrot;
        public string Nr_ewidencyjny => nazwa;
        public long Nr_własny_dokumentu => numer;
        public DateTime? Data_księgowania => numerKsiegowania.HasValue ? datawpr : (DateTime?) null;
        public DateTime? Data_dokumentu =>  datadok;
        public string Opis => tresc;
        public double? kwota_Wn => strona == 0 ? kwota : (double?) null;
        public double?    Kwota_Ma    =>strona == 1 ? kwota : (double?) null;
        public int? Nr_kontarhenta => pozycja;
        public string Nazwa_kontraenta => knazwa;

        public string osoba_księgująca => sygnatura;

        public DateTime? dataokr { get; set; }
        public string skrot { get; set; }
        public int? kontrahentStalyId { get; set; }
        public string nazwa { get; set; }
        public int numer { get; set; }
        public DateTime datawpr { get; set; }
        public DateTime? datadok { get; set; }
        public string tresc { get; set; }
        public string sygnatura { get; set; }
        public int? numerKsiegowania { get; set; }


        public int? synt { get; set; }
        public int poz1 { get; set; }
        public int poz2 { get; set; }
        public int poz3 { get; set; }
        public int poz4 { get; set; }
        public int poz5 { get; set; }
        public short strona { get; set; }
        public double kwota { get; set; }

        public int? pozycja { get; set; }
        public string knazwa { get; set; }

    }
}
