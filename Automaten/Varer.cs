using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Varer
    {
        public string name { get; }
        public int price { get; }
        public int quantity { get; set; }

        public Varer(string _name, int _price, int _quantity) 
        {
            name = _name;

            price = _price;

            quantity = _quantity;
        }

        public void displayName() 
        {
            if (quantity > 0) 
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {name} ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {name}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
