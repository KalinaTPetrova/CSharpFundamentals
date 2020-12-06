using System;
using System.Collections.Generic;
using System.Linq;

namespace Midexam3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> catalogue = new List<string>(Console.ReadLine().Split(", ").ToList());

            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ");
                switch (cmdArgs[0])
                {
                    case "Collect":
                        if (!catalogue.Contains(cmdArgs[1]))
                        {
                            catalogue.Add(cmdArgs[1]);
                        }
                        break;
                    case "Drop":
                        if (catalogue.Contains(cmdArgs[1]))
                        {
                            catalogue.Remove(cmdArgs[1]);
                        }
                        break;
                    case "Renew":
                        if (catalogue.Contains(cmdArgs[1]))
                        {
                            catalogue.Remove(cmdArgs[1]);
                            catalogue.Add(cmdArgs[1]);
                        }
                        break;
                    case "Combine Items":

                        string[] items = cmdArgs[1].Split(":");
                        if (catalogue.Contains(items[0]))
                        {
                            int index = catalogue.IndexOf(items[0]);
                            catalogue.Insert(index+1, items[1]);
                        }
                        break;

                }

                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(", ", catalogue));
        }
    }
}
