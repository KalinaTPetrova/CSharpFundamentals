using System;
using System.Text.RegularExpressions;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(\w+)<<(\d+\.?\d*)!(\d+)";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            Console.WriteLine($"Bought furniture:");
            double sum = 0;
            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    int q = int.Parse(match.Groups[3].Value);
                     sum += price * q;
                    Console.WriteLine(name);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
