using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            kmh = true;
            aktuellegesch = 0;
            maxgesch = 0;
        }
        int maxgesch;
        int aktuellegesch;
        bool kmh;


        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Text = "km/h";
                kmh = true;

            }
            else
            {
                groupBox1.Text = "m/s";
                kmh = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int zw = 0;
            try
            {
                zw = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("max Gschwindigkeit muss eine zahl sein");
            }
            if(zw > 0)
            {
                maxgesch = zw;
            }else
            {
                MessageBox.Show("max Gschwindigkeit muss größer null sein");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(aktuellegesch < (maxgesch-10))
            {
                aktuellegesch += 10;
            }
            else
            {
                aktuellegesch = maxgesch;
            }
            pictureBox1.Invalidate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (aktuellegesch > 10)
            {
                aktuellegesch -= 10;
            }
            else
            {
                aktuellegesch = 0;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics dev = e.Graphics;
            Font font = new Font("Arial", 10);
            if (kmh)
            {
                dev.DrawString("" + aktuellegesch + "km/h", font, Brushes.Black, 10, 10);
                dev.FillRectangle(Brushes.Black, 20, 20, aktuellegesch * 2, 40);
                dev.FillRectangle(Brushes.Black, aktuellegesch*2 - 2 +20 , 20, 4, 50);
            }
            else
            {
                dev.DrawString("" +(double)(aktuellegesch / 3.6) + "m/s", font, Brushes.Black, 10, 10);
                dev.FillRectangle(Brushes.Black, 20, 20,(int) ((aktuellegesch/3.6) * 4)+20, 40);
                dev.FillRectangle(Brushes.Black, (int)((aktuellegesch / 3.6) * 4)-2,20,4,50);
            }
        }
    }
}
