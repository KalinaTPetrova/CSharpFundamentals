using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = new List<string>(Console.ReadLine().Split(", ").ToList());
            string command = Console.ReadLine();
            int blacklistedCount = 0;
            int lostCount = 0;
            while (command != "Report")
            {
                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];

                if (cmd == "Blacklist")
                {
                    string name = cmdArgs[1];
                    if (!friendsList.Contains(name))
                    {
                        Console.WriteLine($"{name} was not found.");

                    }
                    else
                    {
                        int ind = friendsList.IndexOf(name);
                        Edit(ind, "Blacklisted", friendsList);
                        blacklistedCount++;
                        Console.WriteLine($"{name} was blacklisted.");
                        
                    }
                }
                else if (cmd == "Error")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string lostName = friendsList[index];
                    if (friendsList[index] != "Blacklisted" && friendsList[index] != "Lost")
                    {
                        Edit(index, "Lost",friendsList);
                        lostCount++;
                        Console.WriteLine($"{lostName} was lost due to an error.");
                       
                    }
                }

                else if (cmd == "Change")
                {
                    int index1 = int.Parse(cmdArgs[1]);
                    string newName = cmdArgs[2];
                    string oldName = friendsList[index1];
                    if (index1 >= 0 && index1 < friendsList.Count)
                    {
                        friendsList.Remove(friendsList[index1]);
                        friendsList.Insert(index1, newName);
                        Console.WriteLine($"{oldName} changed his username to {newName}.");
                        
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(' ', friendsList));
        }


        private static void Edit(int index, string input, List<string> list)
        {
            list.RemoveAt(index);
            list.Insert(index, input);
        }
    }
    
}
