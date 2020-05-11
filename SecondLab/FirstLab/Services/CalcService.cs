using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstLab.Services
{
    public class CalcService
    {
        public int value { get; private set; }
        public int value2 { get; private set; }

        public CalcService()
        {
            var rand = new Random();

            value = rand.Next(0, 10);
            value2 = rand.Next(0, 10);
        }

        public int Add()
        {
            return value + value2;
        }

        public int Sub()
        {
            return value - value2;
        }

        public int Mult()
        {
            return value * value2;
        }

        public int Div()
        {
            try
            {
                var result = value / value2;
                return result;
            }
            catch (DivideByZeroException)
            {
                Console.Write("error");
                return -1;
            }
        }

    }
}
