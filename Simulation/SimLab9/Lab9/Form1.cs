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

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
        }
        private void Set()
        {
            if (stat.Set(numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value, numericUpDown5.Value)) Get();
            else MessageBox.Show(
                "Не соблюдено условие нормировки!",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void Get()
        {
            chart1.Series[0].Points.Clear();
            decimal[] pointsY = stat.Get();
            for (int i = 0; i < pointsY.Length; i++) chart1.Series[0].Points.AddXY(i + 1, pointsY[i]);
            chart1.Series[0].IsValueShownAsLabel = true;
        }
        
        class Statistic
        {
            int N;
            int[] Stats;
            decimal[] Prob;
            public bool Set(params decimal[] param)
            {
                Prob = new decimal[param.Length];
                Stats = new int[param.Length];
                
                N = (int)param[0];
                
                Prob[param.Length - 1] = 1;
                Stats[param.Length - 1] = 0;
                
                for (int i = 1; i < param.Length; i++)
                {
                    Prob[i - 1] = param[i];
                    Prob[param.Length - 1] -= param[i];
                    Stats[i - 1] = 0;
                }
                
                if (Prob[param.Length - 1] < 0) return false;
                return true;
            }
            
            public decimal[] Get()
            {
                Random rnd = new Random();
                decimal[] Frequency = new decimal[Stats.Length];
                int k; decimal A;
                for (int i = 0; i < N; i++)
                {
                    A = (decimal)rnd.NextDouble();
                    for (k = -1; A > 0; k++) A -= Prob[k + 1];
                    Stats[k]++;
                }
                for (int i = 0; i < Stats.Length; i++)
                {
                    Frequency[i] = (decimal)Stats[i] / N;
                }
                return Frequency;
            }
        }

    }
}