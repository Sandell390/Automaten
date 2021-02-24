using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int userinput = 0;


            Automat.reset();

            do
            {
                do
                {
                    Automat.Display();
                } while (Automat.CoinDeposit());


                userinput = Automat.userchoice();

            } while (Automat.Buy(userinput));

            

            

            Console.ReadKey();



        }
    }
}
