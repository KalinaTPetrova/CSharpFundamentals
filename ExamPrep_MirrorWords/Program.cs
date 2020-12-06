using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExamPrep_MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@|#)([a-zA-Z]{3,})\1\1([a-zA-Z]{3,})\1";
            
            string input = Console.ReadLine();

            var validInput = Regex.Matches(input, pattern);

            var mirror = new List<string>();
           
            if (validInput.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validInput.Count} word pairs found!");

                foreach (Match current in validInput)
                {
                    string one = current.Groups[2].Value;
                    string two = current.Groups[3].Value;

                    string toCompare = Reverse(two);

                    if (one == toCompare)
                    {
                        mirror.Add($"{one} <=> {two}");
                    }
                   
                }                          
                                
            }
            if (mirror.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirror));
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
