using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;

namespace ZapisyExcel
{
    public partial class Form1 : Form
    {
        public string ConnectionString { get; set; } = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (ConnectionString==null)
            {
                using (DataConnectionDialog dcd = new DataConnectionDialog())
                {
                    dcd.DataSources.Add(DataSource.SqlDataSource);
                    dcd.DataSources.Add(DataSource.SqlFileDataSource);
                    dcd.SelectedDataSource = DataSource.SqlDataSource;
                    dcd.SelectedDataProvider = DataProvider.SqlDataProvider;

                    try
                    {
                        if (string.IsNullOrEmpty(ConnectionString) == false)
                            dcd.ConnectionString = ConnectionString;
                    }
                    catch
                    {
                    }

                    if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
                        ConnectionString= dcd.ConnectionString;

                   // return null;
                }
            }
        }
    }
}
