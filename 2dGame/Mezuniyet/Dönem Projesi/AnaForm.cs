using Mezuniyet_Projesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dönem_Projesi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 cs = new Form1();
            cs.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SkorTablosu cs = new SkorTablosu();
            cs.Show();
        }
    }
}
