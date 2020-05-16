using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        bool PauseFlag = false;
        
        Flighter flighter;

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                PauseFlag = true; 
            }
            else if (!timer1.Enabled && PauseFlag) 
            {
                timer1.Start();
                PauseFlag = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
               
                flighter = new Flighter(InputHeight.Value, InputAngle.Value, InputSpeed.Value, InputSize.Value, InputWeight.Value);
                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, InputHeight.Value); // 
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            flighter.NextPosition(); 
            labDistance.Text = "Distance:" + flighter.x0;
            chart1.Series[0].Points.AddXY(flighter.x0, flighter.y0); 
            if (flighter.y0 <= 0) timer1.Stop(); 
        }

      
    }

    class Flighter
    {
        const decimal g = 9.81M, dt = 0.1M, C = 0.15M, rho = 1.29M;
        private double a;
        private decimal cosa, sina, k, vx, vy, v;
        public decimal x0 = 0, y0;
        public Flighter(decimal y0, decimal angle, decimal v0, decimal S, decimal m)
        {
            
            a = (double)angle * Math.PI / 180; 
            cosa = (decimal)Math.Cos(a);
            sina = (decimal)Math.Sin(a);
            k = 0.5M * C * rho * S / m; 
            vx = v0 * cosa; 
            vy = v0 * sina;
        }

        
        public void NextPosition()
        {
            v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            vx = vx - k * vx * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x0 = x0 + vx * dt;
            y0 = y0 + vy * dt;
        }          
         

    }
}
