using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mezuniyet_Projesi;

namespace Dönem_Projesi
{
    public partial class SkorTablosu : Form
    {
        public SkorTablosu()
        {
            InitializeComponent();
        }
        Sql bag = new Sql();
        DataTable t = new DataTable();
        private void SkorTablosu_Load(object sender, EventArgs e)
        {
            t.Clear();
            SqlDataAdapter oda = new SqlDataAdapter("SELECT * FROM SkorTablosu ORDER BY Puanı Desc", bag.baglanti());
            oda.Fill(t);
           // dataGridView1.DataSource = t;
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
