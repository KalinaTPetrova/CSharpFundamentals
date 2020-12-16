using System;
using System.Collections.Generic;
using System.Linq;

namespace Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> composer = new Dictionary<string, string>();
            Dictionary<string, string> key = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] pieces = input.Split("|");

                composer.Add(pieces[0], pieces[1]);
                key.Add(pieces[0], pieces[2]);

            }
            string commands = Console.ReadLine();
            while (commands != "Stop")
            {
                string[] cmdArgs = commands.Split("|");

                if (cmdArgs[0] == "Add")
                {
                    if (!composer.ContainsKey(cmdArgs[1]))
                    {
                        composer.Add(cmdArgs[1], cmdArgs[2]);
                        key.Add(cmdArgs[1], cmdArgs[3]);
                        Console.WriteLine($"{cmdArgs[1]} by {cmdArgs[2]} in {cmdArgs[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{cmdArgs[1]} is already in the collection!");
                    }
                }
                else if (cmdArgs[0] == "Remove")
                {
                    if (!composer.ContainsKey(cmdArgs[1]))
                    {
                        
                        Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
                    }
                    else
                    {
                        composer.Remove(cmdArgs[1]);
                        key.Remove(cmdArgs[1]);
                        Console.WriteLine($"Successfully removed {cmdArgs[1]}!");
                    }
                }
                else if (cmdArgs[0] == "ChangeKey")
                {
                    if (!composer.ContainsKey(cmdArgs[1]))
                    {

                        Console.WriteLine($"Invalid operation! {cmdArgs[1]} does not exist in the collection.");
                    }
                    else
                    {
                        
                        key[cmdArgs[1]]=cmdArgs[2];
                        Console.WriteLine($"Changed the key of {cmdArgs[1]} to {cmdArgs[2]}!");
                    }
                }
                    commands = Console.ReadLine();

            }
                foreach (var item in composer.OrderBy(x=>x.Key).ThenBy(x=>x.Value))
                {
                    Console.WriteLine($"{item.Key} -> Composer: {item.Value}, Key: {key[item.Key]}");
                }
        }
    }
}
