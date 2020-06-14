using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab18
{
    public partial class Form1 : Form
    {
        double time, nextQ, nextO, k, T = 1000, N = 1000, Po, p, fact;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            time = 0; k = 0; Po = 0; p = (double)client.Value / (double)service.Value;

            double[] freq = new double[70];
            double[] stat = new double[70];

            for (int i = 0; i < numOp.Value; i++)
            {
                fact = 1;
                for (int j = 1; j <= i; j++)
                {
                    fact = fact * j;
                }
                Po = Po + Math.Pow(p, i) / fact;
            }
            fact = 1;

            for (int j = 1; j <= numOp.Value; j++)
            {
                fact = fact * j;
            }
            Po = Po + (Math.Pow(p, (double)numOp.Value + 1) / (fact * ((double)numOp.Value - p)));
            Po = Math.Pow(Po, -1);

            Queue queue = new Queue(client.Value);
            Operator operators = new Operator(service.Value, numOp.Value);
  
            while (k < N)
            {
                while (time < T)
                {
                    nextO = operators.NextEvent();
                    nextQ = queue.NextEvent();
 
                    if (nextQ < nextO)
                    {
                        queue.ProcessEvent(operators);
                        time = time + nextQ;
                    }

                    else
                    {
                        operators.ProcessEvent(queue);
                        time = time + nextQ;
                    }
                }
                k++;
                time = 0;
                freq[(operators.NotFreeOperators + queue.ClientsInQueue)]++;
            }

            for (int i = 0; i < 70; i++)
            {
                if (i < numOp.Value)
                {
                    fact = 1;
                    for (int j = 1; j <= i; j++)
                    {
                        fact = fact * j;
                    }
                    stat[i] = (Math.Pow(p, i) / fact) * Po;
                }
                else
                {
                    fact = 1;
                    for (int j = 1; j <= numOp.Value; j++)
                    {
                        fact = fact * j;
                    }
                    stat[i] = (Math.Pow(p, i) / (fact * Math.Pow((double)numOp.Value, i - (double)numOp.Value))) * Po;
                }
                freq[i] = freq[i] / N;
                chart1.Series[0].Points.AddXY(i, freq[i]);
                chart2.Series[0].Points.AddXY(i, stat[i]);
            }
        }
    }

    public class Operator
    {
        
        Random rnd = new Random();
        public int NotFreeOperators, NumOfOperators;
        double num;
        decimal p;
        public Operator(decimal ver, decimal kol)
        {
            p = ver;
            NotFreeOperators = 0;
            NumOfOperators = (int)kol;
        }

        public void ProcessEvent(Queue q)
        {

            if (q.ClientsInQueue == 0)
            {
                NotFreeOperators--;
            }

            else
            {
                q.ClientsInQueue--;
            }
        }

        public double NextEvent()
        {
            if (NotFreeOperators > 0)
            {
                num = rnd.NextDouble() * NotFreeOperators;
                return (-1 * (Math.Log(num) / (double)p));
            }
            else { return 1000000; }
        }
    }

    public class Queue
    {
        decimal p;
        Random rnd = new Random();
        double num;
        public int ClientsInQueue;
        public Queue(decimal ver)
        {
            p = ver;
            ClientsInQueue = 0;
        }

        public void ProcessEvent(Operator op)
        {

            if (op.NotFreeOperators < op.NumOfOperators)
            {
                op.NotFreeOperators++;
            }

            else
            {
                ClientsInQueue++;
            }
        }

        public double NextEvent()
        {
            num = rnd.NextDouble();
            return (-1 * (Math.Log(num) / (double)p));
        }
    }

}
