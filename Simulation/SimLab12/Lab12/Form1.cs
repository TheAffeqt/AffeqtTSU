using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
             
        Team[] team;

        public Form1()
        {
            InitializeComponent();
            team = new Team[8];
            for (int i = 0; i < 8; i++)
                team[i] = new Team();
        }

        void Set()
        {
            int i = 0;
            foreach (NumericUpDown lambda in panel1.Controls)
            {
                team[i].Lambda = (int)lambda.Value;
                team[i].TotalScore = 0; i++;

            }
        }

        void Get()
        {
            label3.Text = "";
            for (int i = 0; i < 7; i++)
            {
               
                for (int j = i + 1; j < 8; j++)
                {
                    label3.Text += "Team " + (i + 1);
                    label3.Text += " vs Team " + (j + 1) + " (" + team[i].Result() + ":" + team[j].Result() + ")\n";
                }
                
                label3.Text += "\n";
            }
            
            int WinnersScore = 0;
            
            for (int i = 0; i < 8; i++)
            {
                if (team[i].TotalScore > WinnersScore) WinnersScore = team[i].TotalScore;
            }
            
            label4.Text = "Winners:\n";
            
            for (int i = 0; i < 8; i++)
            {
                if (team[i].TotalScore == WinnersScore) label4.Text += "Team " + (i + 1) + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
            Get();
        }
        
        class Team
        {
            public int Lambda, TotalScore;
            Random rnd = new Random();
           
            public int Result()
            {
                int goals; double sum = 0;
                for (goals = -1; sum >= -Lambda; goals++) sum += Math.Log(rnd.NextDouble());
                TotalScore += goals;
                
                return goals;
            }
        }
    }
}
