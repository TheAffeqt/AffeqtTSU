using System;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        Statistic stat = new Statistic();
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].Axes[1].Maximum = 1.1;
            chart1.ChartAreas[0].Axes[0].Maximum = 5.5;
        }

        private void Get()
        {
            chart1.Series[0].Points.Clear();
            decimal[] pointsY = stat.Get();
            for (int i = 0; i < pointsY.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, pointsY[i]);

            }
            chart1.Series[0].IsValueShownAsLabel = true;
            label7.Text = "Average: " + stat.Mat() + " (error = " + Math.Round(stat.MatErr(), 3) + "%)";
            label8.Text = "Variance: " + stat.Disp() + " (error = " + Math.Round(stat.DispErr(), 3) + " %)";
            label9.Text = "Chi(sqr): " + stat.ChiCheck();
        }

        private void Set()
        {
            if (stat.Set(numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value, numericUpDown5.Value)) Get();
            else MessageBox.Show(
                "Normality condition violated!",
                "Attention",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
        }
        
        class Statistic
        {
            int N;
            decimal E, E0, D, D0, Chi;
            int[] Stats;
            decimal[] Probs, Freq;
            public bool Set(params decimal[] param)
            {
                Probs = new decimal[param.Length];
                Stats = new int[param.Length];
                Freq = new decimal[param.Length];
                N = (int)param[0]; 
                E = E0 = D = D0 = Chi = 0;
                Probs[param.Length - 1] = 1;
                Stats[param.Length - 1] = 0;
                for (int i = 1; i < param.Length; i++)
                {
                    Probs[i - 1] = param[i];
                    Probs[param.Length - 1] -= param[i];
                    Stats[i - 1] = 0;
                }
                for (int i = 0; i < Probs.Length; i++)
                {
                    E0 += (i + 1) * Probs[i];
                    D0 += (i + 1) * (i + 1) * Probs[i];
                }
                D0 -= E0 * E0;
                if (Probs[param.Length - 1] < 0) return false;
                return true;
            }
            public decimal[] Get()
            {
                Random rnd = new Random();
                Freq = new decimal[Stats.Length];
                int k; decimal A;
                for (int i = 0; i < N; i++)
                {
                    A = (decimal)rnd.NextDouble();
                    for (k = -1; A > 0; k++) A -= Probs[k + 1];
                    Stats[k]++;
                }
                for (int i = 0; i < Stats.Length; i++)
                {
                    Freq[i] = (decimal)Stats[i] / N;
                }
                return Freq;
            }
            public decimal Mat()
            {
                for (int i = 0; i < Freq.Length; i++) E += (i + 1) * Freq[i];
                return E;
            }
            public decimal MatErr()
            {
                return Math.Abs(E - E0) * 100 / Math.Abs(E0);
            }
            public decimal Disp()
            {
                for (int i = 0; i < Freq.Length; i++) D += (i + 1) * (i + 1) * Freq[i];
                D -= E * E;
                return D;
            }
            public decimal DispErr()
            {
                return Math.Abs(D - D0) * 100 / Math.Abs(D0);
            }
            public string ChiCheck()
            {
                for (int i = 0; i < Probs.Length; i++) Chi += Stats[i] * Stats[i] / (N * Probs[i]);
                Chi -= N;
                if (Chi < (decimal)11.07) return Math.Round(Chi, 3) + " < 11.07 correctly";
                else return Math.Round(Chi, 3) + " > 11.07 incorrectly";
            }
        }
    }
}