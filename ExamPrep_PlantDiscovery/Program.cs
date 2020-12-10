using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep_PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary <string, Plant> plants = new Dictionary<string, Plant>();
            
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                Plant plant = new Plant(input[0], int.Parse(input[1]), new List<double> ());
                plants[input[0]]=plant;
                if (plants.ContainsKey(input[0]))
                {
                    plants[input[0]].Update(int.Parse(input[1]));
                }
            }

            string command = Console.ReadLine();
            while (command != "Exhibition")
            {

                string[] splitters = new string[] { ": ", " - " };
                string[] cmdArgs = command.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdArgs[0];
                string plnt = cmdArgs[1];

                if (!plants.ContainsKey(plnt))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();

                    continue;
                }

                if (cmd == "Rate")
                {                    
                    plants[plnt].Rate(double.Parse(cmdArgs[2]));                 
                    
                }
                else if (cmd == "Update")
                {
                    plants[plnt].Update(int.Parse(cmdArgs[2]));
                }
                else if (cmd == "Reset")
                {
                    plants[plnt].Reset();
                }
               

                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating.Sum() / x.Value.Rating.Count))
            {
                Console.WriteLine(item.Value);
            }            

        }
        public class Plant
        {
            public Plant(string name, int rarity, List<double> rating)
            {
                Name = name;
                Rarity = rarity;
                Rating = rating;

            }
            public string Name { get; set; }
            public int Rarity { get; set; }
            public List<double> Rating { get; set; }


            public override string ToString()
            {
                double average = Rating.Count > 0 ? (Rating.Sum() / Rating.Count) : 0;
                return $"- {Name}; Rarity: {Rarity}; Rating: {average:f2}";
            }

            public void Rate (double rating)
            {
                Rating.Add(rating);
                
            }

            public void Update(int rarity)
            {
                Rarity = rarity;
            }

            public void Reset()
            {
                Rating.Clear();
            }

        }
    }
}
    

