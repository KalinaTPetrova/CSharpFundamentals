using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string namePattern = @"[\W\d]";
            string numPattern = @"[\WA-z]";
            string input = Console.ReadLine();
            foreach (var name in names)
            {
                racers.Add(name, 0);
            }
            while (input!="end of race")
            {

                string name = Regex.Replace(input, namePattern, "");
                string dist = Regex.Replace(input, numPattern, "");
                int sum = 0;
                foreach (var item in dist)
                {
                    sum += int.Parse(item.ToString());
                }
                if (racers.ContainsKey(name))
                {
                racers[name] += sum;

                }
                

                input = Console.ReadLine();
            }
            int count = 1;
            foreach (var item in racers.OrderByDescending(x=>x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {item.Key}");
                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
