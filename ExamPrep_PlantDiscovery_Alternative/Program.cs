using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPrep_PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, int>();
            var ratings = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = input[0];
                string rarity = input[1];

                plants[plant] = int.Parse(rarity);
                ratings[plant] = new List<double>();

            }

            string command = Console.ReadLine();
            while (command != "Exhibition")
            {

                string[] splitters = new string[] { ": ", " - " };
                string[] cmdArgs = command.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];
                string plnt = cmdArgs[1];

                if(!plants.ContainsKey(plnt)&&!ratings.ContainsKey(plnt))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }
                if (cmd == "Rate")
                {
                    ratings[plnt].Add(double.Parse(cmdArgs[2]));
                }
                else if (cmd == "Update")
                {
                    plants[plnt] = int.Parse(cmdArgs[2]);
                }
                else if (cmd == "Reset")
                {
                    ratings[plnt].Clear();
                }
                

                command = Console.ReadLine();
            }

            Dictionary<string, double> average = new Dictionary<string, double>();
            foreach (var item in ratings)
            {
                double av = 0;
                if (item.Value.Count > 0)
                {
                    av = item.Value.Sum() / item.Value.Count;
                }
                average.Add(item.Key, av);
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var rarity in plants.OrderByDescending(x => x.Value).ThenByDescending(x => average[x.Key]))
            {
                Console.WriteLine($"- {rarity.Key}; Rarity: {rarity.Value}; Rating: {average[rarity.Key]:f2}");

            }

        }
    }
}
