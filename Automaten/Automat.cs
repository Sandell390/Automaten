using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public static class Automat
    {
        static List<Varer> varer = new List<Varer>();

        static int money;


        static int[] coins = { 1, 2, 5, 10, 20};

        public static void reset() 
        {
            varer.Clear();

            varer.Add(new Varer("Cola", 13, 5));
            varer.Add(new Varer("Fanta", 10, 3));
            varer.Add(new Varer("Mars bar", 20, 10));
            varer.Add(new Varer("Yankie bar", 4, 3));
            varer.Add(new Varer("Faxe kondi", 41, 50));
            varer.Add(new Varer("Peanut", 8, 4));
            varer.Add(new Varer("Monster", 12, 1));
            varer.Add(new Varer("Gaming headset", 17, 20));

        }

        public static void Display() 
        {
            Console.Clear();

            Console.WriteLine("Automat Inator");
            Console.WriteLine($"Money in Automat: {money}");

            Console.WriteLine();

            int currentVare = 0;

            for (int i = 1; i <= varer.Count; i++)
            {
                
                varer[i - 1].displayName();
                if ((i % 3 == 0 || i == varer.Count) && i != 0) 
                {
                    Console.WriteLine();

                    int lastPadLeft = 0;

                    for (int j = i; j < i + 3; j++)
                    {
                        if (currentVare < varer.Count) 
                        {
                            Console.Write(currentVare.ToString().PadLeft(varer[currentVare].name.Length / 2 + lastPadLeft - 2) + " " + varer[currentVare].price + " kr.");
                            lastPadLeft = varer[currentVare].name.Length / 2;
                            currentVare++;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }


            }
        
        }

        public static int userchoice()
        {
            int userint = 0;
            bool canParse;
            do
            {
                Console.WriteLine();
                Console.Write("Choice: ");
                string input = Console.ReadLine();

                canParse = int.TryParse(input, out userint);


                if (!canParse)
                {
                    errorMessage(1);
                    canParse = false;
                }
                else if (userint < 0 || userint > varer.Count - 1)
                {
                    errorMessage(2);
                    canParse = false;
                }

            } while (!canParse);

            return userint;

        }


        public static void errorMessage(int ErrorCode)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You did something wrong! Error code: " + ErrorCode);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static bool CoinDeposit() 
        {
            bool canParse;

            Console.WriteLine();
            Console.Write("Coin: ");
            string input = Console.ReadLine();

            canParse = int.TryParse(input, out int userint);

            if (!canParse)
            {
                errorMessage(4);
            }
            else if (!coins.ToList().Contains(userint))
            {
                errorMessage(3);
            }
            else 
            {
                money += userint;

                Console.WriteLine("Do you want to deposit more? Y/N");

                if (Console.ReadLine().ToLower() == "n")
                {
                    return false;

                }

            }

            return true;
        
        }


        public static bool Buy(int input) 
        {
            List<int> backCoins = new List<int>();

            if (money > varer[input].price) 
            {
                money -= varer[input].price;

                varer[input].quantity--;

                while (money > 0)
                {
                    for (int i = 0; i < coins.Length; i++)
                    {
                        if (money >= coins[i]) 
                        {
                            money -= coins[i];
                            backCoins.Add(coins[i]);
                        }
                    }


                }

            }
            else
            {
                Console.WriteLine("You don't have enoghr money to buy that :/");
                Console.WriteLine("Put some more in the automat");

                return false;


            }

            Console.WriteLine();

            Console.Write("Coin leftover: ");

            backCoins.ForEach(x => Console.Write($"{x} "));

            Console.WriteLine();

            Console.ReadKey();

            return true;
        }

    }
}
