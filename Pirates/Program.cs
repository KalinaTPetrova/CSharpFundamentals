using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep_Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> population = new Dictionary<string, int>();
            Dictionary<string, int> gold = new Dictionary<string, int>();

            while (input != "Sail")
            {
                var cities = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                if (!population.ContainsKey(cities[0])&&!gold.ContainsKey(cities[0]))
                {
                    population.Add(cities[0], 0);
                    gold.Add(cities[0], 0);
                }

                population[cities[0]] += int.Parse(cities[1]);
                gold[cities[0]] += int.Parse(cities[2]);

                input = Console.ReadLine();
            }

            string commands = Console.ReadLine();

            while (commands != "End")
            {
                string[] command = commands.Split("=>");

                if (command[0] == "Plunder")
                {
                    Console.WriteLine($"{command[1]} plundered! {int.Parse(command[3])} gold stolen, {int.Parse(command[2])} citizens killed.");
                    population[command[1]] -= int.Parse(command[2]);
                    gold[command[1]] -= int.Parse(command[3]);

                    if (population[command[1]] <= 0 || gold[command[1]] <= 0)
                    {
                        population.Remove(command[1]);
                        gold.Remove(command[1]);
                        Console.WriteLine($"{command[1]} has been wiped off the map!");
                    }
                }
                else if (command[0] == "Prosper")
                {
                    if (int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        gold[command[1]] += int.Parse(command[2]);
                        Console.WriteLine($"{int.Parse(command[2])} gold added to the city treasury. {command[1]} now has {gold[command[1]]} gold.");
                    }
                }
                commands = Console.ReadLine();
            }

            if (gold.Count > 0)

            {
                Console.WriteLine($"Ahoy, Captain! There are {gold.Count} wealthy settlements to go to:");

                foreach (var town in gold.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {population[town.Key]} citizens, Gold: {town.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
