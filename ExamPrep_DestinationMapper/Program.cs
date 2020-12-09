using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExamPrep_DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)([A-Z][a-zA-Z]{2,})\1";
            string input = Console.ReadLine();
            var validInput = Regex.Matches(input, pattern);
            List <string> destinationsList = new List<string>();
            int points = 0;
            if (validInput.Count > 0)
            {
                foreach (Match destination in validInput)
                {
                    string currentDestination = destination.Groups[2].Value;
                    destinationsList.Add(currentDestination);

                    points += currentDestination.Length;
                }
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinationsList)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
