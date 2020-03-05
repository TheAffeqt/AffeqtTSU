using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int interval;

        double height = 0;
        double angle = 45;
        double speed = 5;

        const double g = 9.81;
        const double delta = 0.1;

        double t = 0;
        
        double sina;
        double cosa;

        
        private void BtGo_Click(object sender, EventArgs e)
        {
            height = (double)editHeight.Value;
            speed = (double)editSpeed.Value;
            angle = (double)editAngle.Value;
            interval = 0;
            textBox1.Text = interval.ToString();
            chart1.ChartAreas[0].AxisX.Maximum = (double)editX.Value;
            chart1.ChartAreas[0].AxisY.Maximum = (double)editY.Value;
            chart1.Series[0].Points.Clear(); 

            t = 0;
            double a = angle * Math.PI / 180;
            sina = Math.Sin(a);
            cosa = Math.Cos(a);

            chart1.Series[0].Points.AddXY(0, height);

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            interval += timer1.Interval;
            textBox1.Text = (interval / 1000).ToString();
            t += delta; 
            double x = speed * cosa * t;
            double y = height + speed * sina * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);

            if (y <= 0) timer1.Stop();
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
