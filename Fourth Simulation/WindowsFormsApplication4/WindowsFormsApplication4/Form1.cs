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
        const double k = 0.02;
        double price;
        double dollars, rubles;
        Random rnd = new Random();
        int i;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            price = (double)InputPrice.Value; 
            chart1.Series[0].Points.AddXY(0, price);
            i = 1;
            dollars = 1000; rubles = 30000; 
            LabelDollars.Text = "Dollars:" + dollars;
            LabelRubles.Text = "Rubles:" + rubles;
        }

        
        private void NextDayButton_Click(object sender, EventArgs e)
        {
          
            if (i == 30)
            {
                chart1.Series[0].Points.Clear();
                i = 1;
            }
            price = price * (1 + k * (rnd.NextDouble() - 0.5)); 
            chart1.Series[0].Points.AddXY(i, price); 
            i++;
        }

        
        private void BuyButton_Click(object sender, EventArgs e)
        {
            
            if (rubles != 0 && (double)InputBuy.Value <= rubles) 
            {
                dollars = dollars + (double)InputBuy.Value / price;
                rubles = rubles - (double)InputBuy.Value;
                LabelDollars.Text = "Dollars:" + dollars;
                LabelRubles.Text = "Rubles:" + rubles;
            }
        }

      
        private void SellButton_Click(object sender, EventArgs e)
        {
            
            if (dollars != 0 && (double)InputSell.Value <= dollars)
            {
                rubles = rubles + (double)InputSell.Value * price;
                dollars = dollars - (double)InputSell.Value;
                LabelDollars.Text = "Dollars:" + dollars;
                LabelRubles.Text = "Rubles:" + rubles;
            }
        }
    }
}
