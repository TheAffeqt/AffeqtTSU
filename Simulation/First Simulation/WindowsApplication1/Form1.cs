using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Simulation
{
    
    public partial class Form1 : Form
    {
        int pasttime = 0;

        float money = 30;

        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
       
        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
            {
                field.Add(cb, new Cell());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked && money >= 2) Plant(cb);
            else Sell(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pasttime += timer1.Interval;
            textBox2.Text = (pasttime / 1000).ToString();
            textBox1.Text = money.ToString();
            foreach (CheckBox cb in panel1.Controls)
              NextStep(cb);
            
        }

        private void Plant(CheckBox cb)
        {
            field[cb].Plant();
            money -= 2;
            UpdateBox(cb);
        }

        private void Harvest(CheckBox cb)
        {
            field[cb].Harvest();
            UpdateBox(cb);
           
        }
        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
 
        }
        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch (field[cb].state)
            {
                case CellState.Planted: c = Color.Black;
                    break;
                case CellState.Green: c = Color.Green;
                    break;
                case CellState.Immature: c = Color.Yellow;
                    break;
                case CellState.Mature: c = Color.Red;
                    break;
                case CellState.Overgrow: c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }
        public void Sell(CheckBox cb)
        {
            switch (field[cb].state)
            {
                case CellState.Green:
                    money+=1;  
                    break;
                case CellState.Immature:
                    money+=2;
                    break;
                case CellState.Mature:
                    money += 3;
                    break;
                case CellState.Overgrow:
                    money -= 1;
                    break;
            }
            Harvest(cb);
        }
        void Button1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        void Button2_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        void Button3_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void label2_Click(object sender, EventArgs e)
        {

        }
    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature,
        Overgrow
    }

    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;

        private const int prPlanted = 20;
        private const int prGreen = 100;
        private const int prImmature = 120;
        private const int prMature = 140;

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;
        }

        public void Harvest()
        {
            state = CellState.Empty;
            progress = 0;
        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrow))
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prImmature) state = CellState.Immature;
                else if (progress < prMature) state = CellState.Mature;
                else state = CellState.Overgrow;
            }
        }

    }
}