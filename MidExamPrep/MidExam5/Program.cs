using System;

namespace MidExam5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double subTotal = 0;
            double total = 0;
            double taxes = 0;
            while (input != "special" || input != "regular")
            {
                input = Console.ReadLine();
                if (input == "special" || input == "regular") { break; }

                double price = double.Parse(input);
                if(price>=0)
                { subTotal += price; }
                else
                {
                    Console.WriteLine($"Invalid price!");
                }
              

            }
            if (subTotal == 0)
            {
                Console.WriteLine($"Invalid order!");
            }
            else
            {
                taxes = subTotal * 0.2;
                total = subTotal + taxes;
                if (input == "special")
                {
                    total *= 0.9;
                }

                Console.WriteLine($"Congratulations you've just bought a new computer!\nPrice without taxes: {subTotal:f2}$\nTaxes: {taxes:f2}$\n-----------\nTotal price: {total:f2}$");
            }
        }
    }

}
