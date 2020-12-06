using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MidExam2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            
            int bitcoins = 0;
            int health = 100;
            int bestRoom = 0;
            bool isKilled = false;

            for (int i = 0; i < rooms.Count; i++)
            {
                List<string> currentRoom = rooms[i].Split().ToList();
                string command = currentRoom[0];
                int num = int.Parse(currentRoom[1]);

                if(command == "potion")
                {

                    if (health + num <= 100)
                    {
                        health += num;
                        Console.WriteLine($"You healed for {num} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        
                        Console.WriteLine($"You healed for {num - ((health+num)-100)} hp.");
                        Console.WriteLine($"Current health: {100} hp.");
                        health = 100;
                    }
                }
                else if (command == "chest")
                {
                    bitcoins += num;
                    Console.WriteLine($"You found {num} bitcoins.");
                }
                else
                {
                    
                    health -= num;

                    if(health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                        
                        bestRoom = i+1;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        bestRoom = i+1;
                        isKilled = true;
                        break;
                    }

                    
                }

            }

            if (isKilled)
            {
                Console.WriteLine($"Best room: {bestRoom}");
            }
            else
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");

            }
        }
    }
}
