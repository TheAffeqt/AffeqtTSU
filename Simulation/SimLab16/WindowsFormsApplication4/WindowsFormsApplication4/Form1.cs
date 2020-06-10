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
        int count;
        double price; 
        double dollars = 150, rubles = 30000;
        
        Random rnd = new Random();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            LabelDollars.Text = "Dollars:" + Math.Round(dollars, 2);
            LabelRubles.Text = "Rubles:" + Math.Round(rubles, 2);

            double mu = (double)MU.Value;
            double sigma = (double)Sigma.Value;
            double steps = 60d;
            double dt = 1d / steps;

            if (price == 0)
            {
                price = (double)InputPrice.Value;
                chart1.Series[0].Points.AddXY(0, price);
            }
            
            else
            {
                count++;
                double n1 = rnd.NextDouble();
                double n2 = rnd.NextDouble();
                double norm = Math.Sqrt(-2.0 * Math.Log(n1)) * Math.Sin(2.0 * Math.PI * n2);
                double gbm = mu * price * dt + sigma * price * norm * Math.Sqrt(dt);
                price += gbm;
                chart1.Series[0].Points.AddXY(count, price);
            }
            
            if (count % 20 == 0) chart1.Series[0].Points.Clear();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            
            if (rubles != 0 && (double)InputBuy.Value <= rubles) 
            {
                dollars += (double)InputBuy.Value / price;
                rubles -= (double)InputBuy.Value;
                LabelDollars.Text = "Dollars:" + Math.Round(dollars, 2);
                LabelRubles.Text = "Rubles:" + Math.Round(rubles, 2);
            }
        }


        private void SellButton_Click(object sender, EventArgs e)
        {
            
            if (dollars != 0 && (double)InputSell.Value <= dollars)
            {
                rubles += (double)InputSell.Value * price;
                dollars -= (double)InputSell.Value;
                LabelDollars.Text = "Dollars:" + Math.Round(dollars, 2);
                LabelRubles.Text = "Rubles:" + Math.Round(rubles, 2);
            }
        }

    }
}
