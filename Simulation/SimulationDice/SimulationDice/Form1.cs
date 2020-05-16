using System;
using System.Windows.Forms;

namespace SimulationDice
{
    public partial class Form1 : Form
    {
        Dice dice = new Dice();
        CheatDice cheatDice = new CheatDice();
        
        int dice1, dice2;
        int sum1, sum2;
        int count, wins, losses;

        public Form1()
        {
            InitializeComponent();
        }
        
        /*                      "Игра два кубика"
        Два игрока бросают свои кубики заранее оговоренное число раз(7)
        Результат каждого броска суммируется
        В конце побеждает тот игрок, у которого сумма оказалась больше
        */
        
        private void RollButton_Click(object sender, EventArgs e)
        {
            if (CheckCheat.Checked == false)
            {
                dice1 = dice.roll();
                dice2 = dice.roll();
            }

            else
            {
                dice1 = cheatDice.roll();
                dice2 = dice.roll();
            }
    
            DiceBox1.Text = dice1.ToString();
            DiceBox2.Text = dice2.ToString();
            
            if (count < 8)
            {
                count++;
                labelCount.Text = "Count of rolls:" + count;
                ResultBox.Text = "";
                sum1 += dice1;
                LabelSum1.Text = "Sum:" +sum1;
                sum2 += dice2;
                LabelSum2.Text = "Sum:" +sum2;

                if ((count == 7) && (sum1 != sum2))
                {
                    if (sum1 > sum2)
                    {
                        ResultBox.Text = "You Win!!!";
                        count = 0; wins++;
                        sum1 = 0; sum2 = 0;
                    }

                    else if (sum1 < sum2)
                    {
                        ResultBox.Text = "You Lose!!!";
                        count = 0; losses++;
                        sum1 = 0; sum2 = 0;
                    }
                }
                
                else if ((count == 7) && (sum1 == sum2))
                {
                    ResultBox.Text = "Draw!!!";
                    count = 0; sum1 = 0; sum2 = 0;
                    wins++; losses++;
                }
                
            }
                   
            LabelLoss.Text = "Enemy wins:" + losses;
            LabelWin.Text = "Your wins:" + wins;
        }

    }
    public class BaseGen
    {
        Random rnd = new Random();
        public double next()
        {
            return rnd.NextDouble();
        }
    }
    
    public class Dice
    {
        BaseGen baseGen = new BaseGen();
        double number;
        public int roll()
        {
            number = baseGen.next();
            int k = 0;
            
            while (number > 0)
            {
                number -= 0.16666666;
                k += 1;
            }
            return k;
        }
    }
    
    // 5 и 6 будут выпадать чаще остальных значений
    public class CheatDice
    {
        BaseGen baseGen = new BaseGen();
        double number;
        public int roll()
        {
            number = baseGen.next();
            int k = 0;
            
            while (number > 0)
            {
                if (k < 4)
                    number -= 0.1;

                else
                    number -= 0.3;

                k += 1;
            }
            return k;
        }
    }
}
