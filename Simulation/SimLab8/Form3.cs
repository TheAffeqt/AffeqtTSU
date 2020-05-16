using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form3 : Form
    {
        MagicBall ball = new MagicBall();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ball.GetAnswer();
        }

    }

    public class MagicBall
    {
        Random rnd = new Random();
        int count = 1;
        double num;
        double temp = 0;
        double[] numbers = new double[16];
        
        public MagicBall()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
           
                numbers[i] = temp;
                temp += 0.05;
            }
 
        }
        public string GetAnswer()
        {
            
            num = rnd.NextDouble();
 
            for(int i = 1; i < numbers.Length ; i++)
            {
                if (num <= numbers[i] & num >= numbers[i - 1])
                    count = i-1;

            }
            switch(count)
            {
                case 0:
                    return "Yes";
                case 1:
                    return "Likely";
                case 2:
                    return "Certainly";
                case 3:
                    return "Undoubtedly";
                case 4:
                    return "Mostly";
                case 5:
                    return "Definitely";
                case 6:
                    return "Maybe yes";
                case 7:
                    return "Surely";
                case 8:
                    return "No";
                case 9:
                    return "Absolutely not";
                case 10:
                    return "Not sure";
                case 11:
                    return "Ask again";
                case 12:
                    return "I can't say";
                case 13:
                    return "I don't know";
                case 14:
                    return "Little chance";
                case 15:
                    return "Hardly";
            }
            return "";
        }
    }
}
