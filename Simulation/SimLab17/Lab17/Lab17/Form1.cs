using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab17
{
    public partial class Form1 : Form
    {
        Flow flow;

        public Form1()
        {
            InitializeComponent();
            flow = new Flow();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            flow.Stat();

            for (int i=0; i < 1000 ;i++)
            {
                if(flow.freq[i] != 0) chart1.Series[0].Points.AddXY(i, flow.freq[i]);
                if (flow.stat[i] != 0) chart1.Series[1].Points.AddXY(i, flow.stat[i]);
                
            }
        }
    }

    public class Flow
    {
        public double[] freq = new double[1000];
        public double[] stat = new double[1000];
        public double  a, lambda1 = 0.3, lambda2 = 0.2,sum, t1=0, t2=0, tsum=0;

        private int flow1 = 0, flow2 = 0, flowSum=0, T=1000, N=1000;

        Random rnd = new Random();

        private void Gen()
        {

            flow1 = flow2 = flowSum = 0;
            t1 = t2 = tsum = 0;
            while (t1 < T || t2 < T || tsum < T)
            {
                a = rnd.NextDouble();
                if (t1 < T)
                {
                    t1 += (-Math.Log(a) / lambda1);
                    flow1++;
                }
                if (t2 < T)
                {
                    t2 += (-Math.Log(a) / lambda2);
                    flow2++;
                }
                if (tsum < T)
                {
                    tsum += (-Math.Log(a) / sum);
                    flowSum++;
                }
            }
        }

        public void Stat()
        {
            
            sum = lambda1 + lambda2;
            for (int i = 0; i < 1000; i++)
            {
                freq[i] = 0;
                stat[i] = 0;
            }
            for (int i = 0; i < N; i++)
            {
                Gen();
                freq[flow1 + flow2]++;
                stat[flowSum]++;
            }

            for (int i = 0; i < 1000; i++)
            {
                freq[i]/= N;
                stat[i]/= N;
            }

        }

    }
}
