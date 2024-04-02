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
using System.Data.SqlClient;
using Dönem_Projesi;

namespace Mezuniyet_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Sql bgl = new Sql();


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < rndengel.Length; i++)
            {
                rndengel[i] = new Random_Engel();
            }
            rndengel[0].vakit = true;
            KarekterYerine();
            label8.Text = Settings1.Default.YüksekSkor.ToString();
        }

        private void labelSolSerit5_Click(object sender, EventArgs e)
        {

        }
        int yön = 1, Road = 0, Speed = 70 , skor=0;
        Random R = new Random();

        class Random_Engel
        {
            public bool EngelGetir = false;
            public PictureBox engel;
            public bool vakit = false;
        }

        Random_Engel[] rndengel = new Random_Engel[2];

     
        void EngelGetir2(PictureBox pb)
        {
            int rnd = R.Next(0, 3);

            switch (rnd)
            {
                case 0:

                    pb.Image = Dönem_Projesi.Properties.Resources._3;
                    break;

                case 1:
                    pb.Image = Dönem_Projesi.Properties.Resources._2;
                    break;

                case 2:
                    pb.Image = Dönem_Projesi.Properties.Resources._1;

                    break;

            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        

        

        }
        private void KarekterYerine()
        {
            if (yön == 1)
            {
                Karekter.Location = new Point(198, 369);
            }

            else if (yön == 0)
            {
                Karekter.Location = new Point(55, 373);
            }
            else if (yön == 2)
            {
                Karekter.Location = new Point(390, 373);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (yön < 2)
                    yön++;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (yön > 0)
                    yön--;
            }

            KarekterYerine();
        }

        private void Karekter_Click(object sender, EventArgs e)
        {

        }



   

        void seviye()
        {
            if (Road > 50 && Road < 150)
            {
                Speed = 200;
                tmrengel.Interval = 200;
                timeryon.Interval = 140;

            }

            else if (Road >150 && Road < 300 )
            {
                Speed = 250;
                tmrengel.Interval = 225;
                timeryon.Interval = 100;
            }
            else if (Road > 300 && Road < 550)
            {
                Speed = 400;
                tmrengel.Interval = 200;
                timeryon.Interval = 80;
            }
            else if (Road > 150 && Road < 300)
            {
                Speed = 500;
                tmrengel.Interval = 250;
                timeryon.Interval = 20;
            }

        }



        private void tmrengel_Tick(object sender, EventArgs e)
        {
            
            seviye();
    
            Road += 1;

            

            if (SeritHareket == false)
            {
                for (int i = 1; i < 7; i++)
                {
                    this.Controls.Find("labelSolSerit" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("labelSagSerit" + i.ToString(), true)[0].Top -= 25;
                    SeritHareket = true;
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    this.Controls.Find("labelSolSerit" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("labelSagSerit" + i.ToString(), true)[0].Top += 25;
                    SeritHareket = false;
                }
            }

            lblyol.Text = Road.ToString() + "m";
            label5.Text = Speed.ToString() + "km/h";


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        bool SeritHareket = false;
   
        private void timeryon_Tick(object sender, EventArgs e)
        {

            
            for (int i = 0; i < rndengel.Length; i++)
            {
                if (!rndengel[i].EngelGetir && rndengel[i].vakit)
                {
                    rndengel[i].engel = new PictureBox();
                    EngelGetir2(rndengel[i].engel);
                    rndengel[i].engel.Size = new Size(90, 150);
                    rndengel[i].engel.Top = -rndengel[i].engel.Height;

                    int sol_Yerles = R.Next(0, 3);

                    if (sol_Yerles == 0)
                    {

                        rndengel[i].engel.Left = 55;

                    }
                    else if (sol_Yerles == 1)
                    {
                        rndengel[i].engel.Left = 210;
                    }

                    else if (sol_Yerles == 2)
                    {
                        rndengel[i].engel.Left = 390;
                    }


                    this.Controls.Add(rndengel[i].engel);
                    rndengel[i].EngelGetir = true;

                }

                else
                {
                    if (rndengel[i].vakit)
                    {
                        rndengel[i].engel.Top += 20;
                        if (rndengel[i].engel.Top >= 154)
                        {
                            for (int j = 0; j < rndengel.Length; j++)
                            {
                                if (!rndengel[j].vakit)
                                {
                                    rndengel[j].vakit = true;
                                    break;
                                }
                            }
                        }
                        if (rndengel[i].engel.Top >= this.Height - 20)
                        {
                            rndengel[i].engel.Dispose();
                            rndengel[i].EngelGetir = false;
                            rndengel[i].vakit = false;
                        }
                    }

                }

                if (rndengel[i].vakit)
                {
                    float mutlakX = Math.Abs((Karekter.Left + (Karekter.Width / 2)) - (rndengel[i].engel.Left + (rndengel[i].engel.Width / 2)));
                    float mutlakY = Math.Abs((Karekter.Top + (Karekter.Height / 2)) - (rndengel[i].engel.Top + (rndengel[i].engel.Height / 2)));
                    float FarkGenislik = (Karekter.Width / 2) + (rndengel[i].engel.Width / 2);
                    float FarkYukseklik = (Karekter.Height / 2) + (rndengel[i].engel.Height / 2);

                    if ((FarkGenislik > mutlakX) && (FarkYukseklik > mutlakY))
                    {
                        timeryon.Enabled = false;
                        tmrengel.Enabled = false;

                        if (Road > Settings1.Default.YüksekSkor)
                        {
                            MessageBox.Show("New High Score ==> " + Road.ToString() + "m", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings1.Default.YüksekSkor = Road;
                            Settings1.Default.Save();
                        }
                        DialogResult dr = MessageBox.Show("Oyunumuz sona erdi tekrar oynamak istermisiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            KarekterYerine();

                            for (int j = 0; j < rndengel.Length; j++)
                            {
                                rndengel[j].engel.Dispose();
                                rndengel[j].EngelGetir = false;
                                rndengel[j].vakit = false;
                            }
                            Road = 0;
                            Speed = 70;
                            rndengel[0].vakit = true;
                            timeryon.Enabled = true;
                            timeryon.Interval = 200;

                            tmrengel.Interval = 200;
                            tmrengel.Enabled = true;
                            label8.Text = Settings1.Default.YüksekSkor.ToString();

                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}

         

