using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab15
{
    public partial class Form1 : Form
    {
        Weather weather;
        Random rnd = new Random();
        
        int modeling;
        
        double a, time;
        double[] Q;
        
        public Form1()
        {
            InitializeComponent();
            weather = new Weather();
            Q = new double[3] { -0.4, -0.8, -0.5 };
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            time = 0;
            modeling = 0;
            
            chart1.Series[0].Points.Clear();
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            weather.GetStat();

            for (int i = 0; i < 3; i++)
            {
                chart2.Series[0].Points.AddXY(i + 1, weather.Freq[i]);
                chart2.Series[1].Points.AddXY(i + 1, weather.Theory[i]);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY((int)time, modeling + 1);
            a = rnd.NextDouble();

            time += Math.Log(a) / Q[modeling];
            modeling = weather.WeatherModeling(a);
        }

    }

    public class Weather
    {
        int modeling = 0;
        int N = 1000;
        int T = 1000;
        
        Random rnd = new Random();
        
        double a;
        double[,] Q = new double[3, 3] { { -0.4, 0.3, 0.1 }, { 0.4, -0.8, 0.4 }, { 0.1, 0.4, -0.5 } };
        public double[] Freq = new double[3];
        public double[] Theory = new double[3];

        

        public int WeatherModeling(double a)
        {
            for (int i = 0; i < 3; i++)
            {
                if (modeling != i)
                    a -= Q[modeling, i] / Math.Abs(Q[modeling, modeling]);
                else
                    a -= 0;
                
                if (a < 0)
                {
                    modeling = i;
                    return modeling;
                }
            }
            
            return modeling;
        }
        
        public int Gen()
        {
            for (int i = 0; i < 3; i++)
            {
                if (modeling != i)
                    a -= Q[modeling, i] / Math.Abs(Q[modeling, modeling]);
                else
                    a -= 0;
                
                if (a < 0)
                {
                    modeling = i;
                    return modeling;
                }
            }
            
            return modeling;
        }

        public void GetStat()
        {
            modeling = 0;
            
            for (int i = 0; i < 3; i++)
            {
                Freq[i] = 0;
                Theory[i] = 0;
            }
            
            p();
            
            for (int i = 0; i < N; i++)
            {
                for (double j = 0; j < T;)
                {
                    a = rnd.NextDouble();
                    Gen();
                    j += Math.Log(a) / Q[modeling, modeling];
                }
                Freq[modeling] = Freq[modeling] + 1;
            }
            
            for (int i = 0; i < 3; i++) Freq[i] /= N;
        }

        public void p()
        {
            for(int i=0; i<3; i++)
            Theory[i]=(-Q[i,i])*Math.Exp(-(-Q[i, i]));
        }

    }
}
