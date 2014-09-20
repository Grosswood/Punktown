using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punktown
{
    class First
    {
        static int d(int dice)
        {
//Private random            
            Random random = new Random();
            return (random.Next(1, dice));
        }

        static int D(int dice)
        {
//Public random
            Random random = new Random();
            int diceValue = random.Next(1, dice);
            Console.WriteLine("d" + dice + " rolls for " + diceValue);
            return (diceValue);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(d(10));
            D(20);
        }
    }
}
