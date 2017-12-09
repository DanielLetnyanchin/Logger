using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLog logger = new MyLog();
            var temp = new List<int>();
            var rand = new Random();
            for (int i = 1; i < 10; i++)
            {
                temp.Add(i);
            }
            for (int i = 0; i < 20; i++)
            {
                var x = rand.Next(0, 20);
                try
                {
                    
                    temp[x] = temp[x];
                    logger.Log(LogLevel.Info, $"Rand was {x}", null, null);
                }
                catch(Exception ex)
                {
                    logger.Error($"Rand was {x} and throw: {ex.Message}", ex.Source, ex.StackTrace);
                }
            }
            Console.WriteLine("------------------------");
            Console.ReadKey();
        }
    }
}
