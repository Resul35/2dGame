using Mezuniyet_Projesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dönem_Projesi
{
    public partial class giriş : Form
    {
        public giriş()
        {
            InitializeComponent();
        }
        Sql bgl = new Sql();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand a = new SqlCommand ();
            a.Connection = bgl.baglanti();
            a.CommandText = "insert into kullanıcı(Adı) values (@ADI)";
            a.Parameters.AddWithValue("@ADI", txtkullanıcı.Text);
            a.ExecuteNonQuery();

            AnaForm cs = new AnaForm();
        
            cs.Show();
            
         
        }

        private void giriş_Load(object sender, EventArgs e)
        {

        }
    }
}
