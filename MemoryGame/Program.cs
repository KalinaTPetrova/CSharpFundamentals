using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            int countMoves = 0;
            int success = 0;
            string indeces = Console.ReadLine();
            while (indeces != "end")
            {
                string[] commands = indeces.Split();
                int index1 = int.Parse(commands[0]);
                int index2 = int.Parse(commands[1]);

                
                countMoves++;
                if (index1 == index2 || index1 < 0 || index2 < 0 || index1 >= input.Count || index2 >= input.Count)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string[] toAdd = new string[] {$"-{countMoves}a", $"-{countMoves}a"};
                    input.InsertRange(input.Count/2, toAdd);
                    
                }

                else if (input[index1] == input[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {input[index1]}!");

                    string remove = input[index1];
                    input.RemoveAll(x=>x==remove);
                    
                   
                    success++;
                }
                else if(input[index1] != input[index2])
                {
                    Console.WriteLine("Try again!");
                }

                if (input.Count == 0)
                {
                    Console.WriteLine($"You have won in {countMoves} turns!");
                    break;
                }
                indeces = Console.ReadLine();

            }
            if (input.Count > 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ", input));
                   

            }
        }
    }
}
